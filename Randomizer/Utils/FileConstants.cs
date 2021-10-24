using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer.Randomizer.Data
{
    static class FileConstants
    {
        public static string TEXT_DATA_KEY = "text-data";
        public static string[] FILES_TO_READ = { TEXT_DATA_KEY };

        public static string TEXT_DATA_CAB_DIR = "CAB-69ae4a77338c6711e85a72e9f85eed3c";
        public static Dictionary<string, string> FILES_CAB_DIRECTORIES = new Dictionary<string, string> { { TEXT_DATA_KEY, TEXT_DATA_CAB_DIR } };

        public static string TEXT_DATA_ENEMY_DATA_CLASS_NAME = "EnemyData";
        public static string TEXT_DATA_ENEMY_DATA_SCRIPT = "m_Script";
    }
}
