using System;
using System.Collections.Generic;
using System.IO;

namespace ICExample.Resources {
    public class CommonPasswordLists {
        public Lazy<HashSet<string>> Top10kPasswords { get; }
        public Lazy<HashSet<string>> Top100kPasswords { get; }

        public CommonPasswordLists() {
            var resourcesDir = $"{Directory.GetCurrentDirectory()}/Resources";

            var top10kPasswords = $"{resourcesDir}/top10kPasswords.txt";
            var top100kPasswords = $"{resourcesDir}/top100kPasswords.txt";

            Top10kPasswords = new Lazy<HashSet<string>>(() => LoadPasswordList(top10kPasswords));
            Top100kPasswords = new Lazy<HashSet<string>>(() => LoadPasswordList(top100kPasswords));
        }

        private HashSet<string> LoadPasswordList(string fileName) {
            using(var streamReader = new StreamReader(fileName)) {
                return new HashSet<string>(GetLines(streamReader), StringComparer.OrdinalIgnoreCase);
            }
        }

        private IEnumerable<string> GetLines(StreamReader reader) {
            while(!reader.EndOfStream) {
                yield return reader.ReadLine();
            }
        }
    }
}
