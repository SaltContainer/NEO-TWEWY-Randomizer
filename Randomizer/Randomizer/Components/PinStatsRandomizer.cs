using System;
using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class PinStatsRandomizer
    {
        private RandomizationEngine engine;

        public PinStatsRandomizer(RandomizationEngine engine)
        {
            this.engine = engine;
        }

        private Dictionary<Badge.Label, List<AttackHit>> FindAttackHitsToModify(List<Badge> pins, AttackHitList dataToSearch)
        {
            PsychicList psychicDataOriginal = engine.Bundles.TextData.GetPsychic();
            AttackComboSetList attackComboSetDataOriginal = engine.Bundles.TextData.GetAttackComboSet();
            AttackList attackDataOriginal = engine.Bundles.TextData.GetAttack();

            Dictionary<Badge.Label, Psychic> psDict = pins.ToDictionary(p => p.Id, p => psychicDataOriginal.Items.Where(ps => ps.Id == p.Psychic).First());
            Dictionary<Badge.Label, AttackComboSet> acsDict = psDict.ToDictionary(ps => ps.Key, ps => attackComboSetDataOriginal.Items.Where(acs => acs.Id == ps.Value.AttackComboSet).First());
            Dictionary<Badge.Label, List<Attack>> atkDict = acsDict.ToDictionary(acs => acs.Key, acs => attackDataOriginal.Items.Where(atk => acs.Value.AttackList.Contains(atk.Id)).ToList());
            Dictionary<Badge.Label, List<AttackHit>> hitDict = atkDict.ToDictionary(atk => atk.Key, atk => dataToSearch.Items.Where(hit => atk.Value.SelectMany(a => a.HitList).Contains(hit.Id)).ToList());

            return hitDict;
        }

        public void RandomizePinStats(RandomizationSettings settings)
        {
            BadgeList pinDataOriginal = engine.Bundles.TextData.ParseBadge();
            BadgeList pinData = engine.Bundles.TextData.GetBadge();

            AttackHitList attackHitDataOriginal = engine.Bundles.TextData.ParseAttackHit();
            AttackHitList attackHitData = engine.Bundles.TextData.GetAttackHit();

            List<Badge> listToEditOriginal = pinDataOriginal.Items.Where(data => FileConstants.ItemNames.Pins.Select(p => (Badge.Label)p.Id).Contains(data.Id)).ToList();
            List<Badge> listToEdit = pinData.Items.Where(data => FileConstants.ItemNames.Pins.Select(p => (Badge.Label)p.Id).Contains(data.Id)).ToList();

            Dictionary<Badge.Label, List<AttackHit>> attackHitToEdit = FindAttackHitsToModify(listToEdit, attackHitData);

            if (settings.PinStats.MaxLevel) listToEdit.ForEach(p => p.MaxLevel = engine.RandNext(2, 11));

            if (settings.PinStats.Power) listToEdit.ForEach(p => p.Power = engine.RandNext(50, 1401));
            if (settings.PinStats.PowerScaling) listToEdit.ForEach(p => p.PowerScaling = engine.RandNext(0, 101));

            if (settings.PinStats.Limit) listToEdit.ForEach(p => p.Limit = engine.RandNext(3, 11));
            if (settings.PinStats.LimitScaling) listToEdit.ForEach(p => p.LimitScaling = engine.RandNext(0, 3));

            if (settings.PinStats.Reboot) listToEdit.ForEach(p => p.Reboot = engine.RandNextRoundedFloatRange(5, 20, 1));
            if (settings.PinStats.RebootScaling) listToEdit.ForEach(p => p.RebootScaling = engine.RandNextRoundedFloatRange(0, Math.Max(0, (p.Reboot - 1) / (p.MaxLevel - 1) - 0.1), 1));

            if (settings.PinStats.Boot) listToEdit.ForEach(p => p.Boot = Math.Max(0, engine.RandNextRoundedFloatRange(-6, 6, 1)));
            if (settings.PinStats.BootScaling) listToEdit.ForEach(p => p.BootScaling = engine.RandNextRoundedFloatRange(0, Math.Max(0, (p.Boot) / (p.MaxLevel - 1) - 0.1), 1));

            if (settings.PinStats.Recover) listToEdit.ForEach(p => p.Recover = p.Reboot + engine.RandNextRoundedFloatRange(0, 6, 1));
            if (settings.PinStats.RecoverScaling) listToEdit.ForEach(p => p.RecoverScaling = engine.RandNextRoundedFloatRange(0, Math.Max(0, (p.Recover - 1) / (p.MaxLevel - 1) - 0.1), 1));

            if (settings.PinStats.Charge) listToEdit.ForEach(p => p.Charge = engine.RandNextRoundedFloatRange(0, 2, 1));

            if (settings.PinStats.Sell) listToEdit.ForEach(p => p.SellPrice = engine.RandNext(500, 10001));
            if (settings.PinStats.SellScaling) listToEdit.ForEach(p => p.SellPriceScaling = engine.RandNext(500, 2001));

            if (settings.PinStats.Affinity)
            {
                listToEdit.ForEach(p => {
                    p.MashUpAffinity = (ElementType)FileConstants.ItemNames.Affinities[engine.RandNext(FileConstants.ItemNames.Affinities.Count)].Id;
                    attackHitToEdit[p.Id].ForEach(hit => hit.Affinity[0] = p.MashUpAffinity);
                });
            }

            switch (settings.PinStats.BrandChoice)
            {
                case PinBrand.Shuffle:
                {
                    List<BrandLabel> brands = [];
                    brands.AddRange(listToEdit.Select(p => p.Brand));

                    brands = brands.OrderBy(b => engine.RandNext()).ToList();

                    for (int i=0; i<listToEdit.Count; i++)
                        listToEdit[i].Brand = brands[i];
                }
                break;

                case PinBrand.RandomCompletely:
                {
                    listToEdit.ForEach(p => p.Brand = (BrandLabel)engine.RandNext(0, 16));
                }
                break;

                case PinBrand.RandomUniform:
                {
                    List<BrandLabel> brands = [];
                    brands.AddRange(FileConstants.ItemNames.Brands.Select(b => (BrandLabel)b.Id));

                    brands = brands.OrderBy(b => engine.RandNext()).ToList();

                    List<int> pins = Enumerable.Range(0, listToEdit.Count).ToList();
                    pins = pins.OrderBy(pin => engine.RandNext()).ToList();

                    int brandId = 0;
                    foreach (int i in pins)
                    {
                        listToEdit[i].Brand = brands[brandId % brands.Count];
                        brandId++;
                    }
                }
                break;
            }

            if (settings.PinStats.Uber)
            {
                List<int> pins = Enumerable.Range(0, listToEdit.Count).ToList();
                pins = pins.OrderBy(pin => engine.RandNext()).ToList();

                float percentage = settings.PinStats.UberPercentage / 100f;
                int count = (int)(pins.Count * percentage);

                for (int i=0; i<listToEdit.Count; i++)
                {
                    listToEdit[pins[i]].Uber = i < count ? BadgeRarityType.Rare : BadgeRarityType.Normal;
                    listToEdit[pins[i]].PinClass = i < count ? BadgeClassLabel.God : BadgeClassLabel.C;
                }
            }

            switch (settings.PinStats.AbilityChoice)
            {
                case PinAbility.Shuffle:
                {
                    List<IList<AbilityAbility>> abilities = [];
                    abilities.AddRange(listToEdit.Select(p => p.Abilities));

                    abilities = abilities.OrderBy(b => engine.RandNext()).ToList();

                    for (int i=0; i<listToEdit.Count; i++)
                        listToEdit[i].Abilities = abilities[i];
                }
                break;

                case PinAbility.RandomCompletely:
                {
                    List<int> abilities = Enumerable.Range(0, listToEdit.Count).ToList();
                    abilities = abilities.OrderBy(pin => engine.RandNext()).ToList();

                    float percentage = settings.PinStats.AbilityPercentage / 100f;
                    int count = (int)(abilities.Count * percentage);

                    for (int i=0; i<listToEdit.Count; i++)
                    {
                        listToEdit[abilities[i]].Abilities.Clear();
                        if (i < count) listToEdit[abilities[i]].Abilities = new List<AbilityAbility>() { (AbilityAbility)FileConstants.ItemNames.PinAbilities[engine.RandNext(FileConstants.ItemNames.PinAbilities.Count)].Id };
                    }
                }
                break;
            }

            switch (settings.PinStats.GrowthChoice)
            {
                case PinGrowthRandomization.RandomCompletely:
                {
                    listToEdit.ForEach(p => p.Growth = (BadgeLvUpTypeLabel)FileConstants.ItemNames.GrowthRates[engine.RandNext(FileConstants.ItemNames.GrowthRates.Count)].Id);
                }
                break;

                case PinGrowthRandomization.RandomUniform:
                {
                    List<BadgeLvUpTypeLabel> growths = [];
                    growths.AddRange(FileConstants.ItemNames.GrowthRates.Select(r => (BadgeLvUpTypeLabel)r.Id));

                    List<int> pins = Enumerable.Range(0, listToEdit.Count).ToList();
                    pins = pins.OrderBy(pin => engine.RandNext()).ToList();

                    uint growthId = 0;
                    foreach (int i in pins)
                    {
                        listToEdit[i].Growth = growths[(int)(growthId % growths.Count)];
                        growthId++;
                    }
                }
                break;

                case PinGrowthRandomization.Specific:
                {
                    listToEdit.ForEach(p => p.Growth = (BadgeLvUpTypeLabel)settings.PinStats.GrowthSpecific);
                }
                break;
            }

            switch (settings.PinStats.EvolutionChoice)
            {
                case PinEvolution.RandomExisting:
                {
                    foreach (Badge data in listToEdit)
                    {
                        List<Badge.Label> possibleEvos;
                        if (settings.PinStats.EvoForceBrand) possibleEvos = listToEdit.Where(p => p.Brand == data.Brand).Select(p => p.Id).ToList();
                        else possibleEvos = FileConstants.ItemNames.Pins.Select(p => (Badge.Label)p.Id).ToList();

                        if (data.EvolutionSingle != Badge.Label.Invalid)
                        {
                            data.EvolutionSingle = possibleEvos[engine.RandNext(possibleEvos.Count)];
                            data.EvolutionLevel = data.MaxLevel;
                        }
                        for (int i=0; i<data.EvolutionList.Count; i++)
                        {
                            if (data.EvolutionList[i] != Badge.Label.Invalid)
                            {
                                data.EvolutionList[i] = possibleEvos[engine.RandNext(possibleEvos.Count)];
                                data.EvolutionLevel = data.MaxLevel;
                            }
                        }
                    }
                }
                break;

                case PinEvolution.RandomCompletely:
                {
                    List<int> pins = Enumerable.Range(0, listToEdit.Count).ToList();
                    pins = pins.OrderBy(pin => engine.RandNext()).ToList();

                    float percentage = settings.PinStats.EvoPercentage / 100f;
                    int count = (int)(pins.Count * percentage);

                    for (int i=0; i<listToEdit.Count; i++)
                    {
                        if (i < count)
                        {
                            List<Badge.Label> possibleEvos;
                            if (settings.PinStats.EvoForceBrand) possibleEvos = listToEdit.Where(p => p.Brand == listToEdit[pins[i]].Brand).Select(p => p.Id).ToList();
                            else possibleEvos = FileConstants.ItemNames.Pins.Select(p => (Badge.Label)p.Id).ToList();

                            bool single = engine.RandNext(3) < 2;
                            if (single)
                            {
                                listToEdit[pins[i]].EvolutionSingle = possibleEvos[engine.RandNext(possibleEvos.Count)];
                                listToEdit[pins[i]].EvolutionList.Clear();
                            }
                            else
                            {
                                int chara = engine.RandNext(7);
                                listToEdit[pins[i]].EvolutionSingle = Badge.Label.Invalid;
                                listToEdit[pins[i]].EvolutionList = Enumerable.Repeat(Badge.Label.Invalid, 7).ToList();
                                listToEdit[pins[i]].EvolutionList[chara] = possibleEvos[engine.RandNext(possibleEvos.Count)];
                            }
                            listToEdit[pins[i]].EvolutionLevel = listToEdit[pins[i]].MaxLevel;
                        }
                        else
                        {
                            listToEdit[pins[i]].EvolutionSingle = Badge.Label.Invalid;
                            listToEdit[pins[i]].EvolutionList.Clear();
                            listToEdit[pins[i]].EvolutionLevel = 0;
                        }
                    }
                }
                break;
            }

            if (settings.PinStats.RemoveCharaEvos)
            {
                foreach (Badge data in listToEdit)
                {
                    if (data.EvolutionList.Count > 0)
                    {
                        data.EvolutionSingle = data.EvolutionList.Where(i => i != Badge.Label.Invalid).First();
                        data.EvolutionList.Clear();
                    }
                }
            }

            engine.Logger.LogPinStatsChanges(listToEditOriginal, listToEdit);
        }
    }
}
