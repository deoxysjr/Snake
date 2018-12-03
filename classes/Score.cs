using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Score
    {
        public string HighScore1 { get; set; }
        public string HighScore2 { get; set; }
        public string HighScore3 { get; set; }

        public Score()
        {
            HighScore1 = "0";
            HighScore2 = "0";
            HighScore3 = "0";
        }

        public void LoadUser(string username)
        {
            List<string> EnCryScoreslist = File.ReadAllLines($"./users/{username}.gsf").ToList();
            List<int> DeCryScoreslist = new List<int>();
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes("3e8dGhzZjcyCnMeUFHZ8jSsg"));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        foreach(string encry in EnCryScoreslist)
                        {
                            byte[] cipherBytes = Convert.FromBase64String(encry);
                            byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                            DeCryScoreslist.Add(int.Parse(Encoding.UTF8.GetString(bytes)));
                        }
                    }
                }
            }
            int[] ScoreArray = DeCryScoreslist.ToArray().OrderByDescending(c => c).ToArray();
            if (DeCryScoreslist.Count == 0)
            {
                HighScore1 = "0";
                HighScore2 = "0";
                HighScore3 = "0";
            }
            else if (DeCryScoreslist.Count == 1)
            {
                HighScore1 = ScoreArray[0].ToString();
                HighScore2 = "0";
                HighScore3 = "0";
            }
            else if (DeCryScoreslist.Count == 2)
            {
                HighScore1 = ScoreArray[0].ToString();
                HighScore2 = ScoreArray[1].ToString();
                HighScore3 = "0";
            }
            else
            {
                HighScore1 = ScoreArray[0].ToString();
                HighScore2 = ScoreArray[1].ToString();
                HighScore3 = ScoreArray[2].ToString();
            }
        }

        public void SaveScore(int score, string username)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    string key = "3e8dGhzZjcyCnMeUFHZ8jSsg";
                    tdes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = Encoding.UTF8.GetBytes(score.ToString());
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        File.AppendAllText($"./users/{username}.gsf", Convert.ToBase64String(bytes, 0, bytes.Length) + "\r\n");
                    }
                }
            }
        }

        public void UpdateScore(string username)
        {
            List<string> EnCryScoreslist = File.ReadAllLines($"./users/{username}.gsf").ToList();
            List<int> DeCryScoreslist = new List<int>();
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes("3e8dGhzZjcyCnMeUFHZ8jSsg"));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        foreach (string encry in EnCryScoreslist)
                        {
                            byte[] cipherBytes = Convert.FromBase64String(encry);
                            byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                            DeCryScoreslist.Add(int.Parse(Encoding.UTF8.GetString(bytes)));
                        }
                    }
                }
            }

            DeCryScoreslist.Sort();
            DeCryScoreslist.Reverse();
            if (DeCryScoreslist.Count == 0)
            {
                HighScore1 = "0";
                HighScore2 = "0";
                HighScore3 = "0";
            }
            else if (DeCryScoreslist.Count == 1)
            {
                HighScore1 = DeCryScoreslist[0].ToString();
                HighScore2 = "0";
                HighScore3 = "0";
            }
            else if (DeCryScoreslist.Count == 2)
            {
                HighScore1 = DeCryScoreslist[0].ToString();
                HighScore2 = DeCryScoreslist[1].ToString();
                HighScore3 = "0";
            }
            else
            {
                HighScore1 = DeCryScoreslist[0].ToString();
                HighScore2 = DeCryScoreslist[1].ToString();
                HighScore3 = DeCryScoreslist[2].ToString();
            }
        }
    }
}
