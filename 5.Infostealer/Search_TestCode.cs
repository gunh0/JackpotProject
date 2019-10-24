using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace HackingPOS.Scrapers.Common
{
    public enum ResultTypes { Track1 = 1, Track2, PAN };

    public class SearchResult
    {
        public string FileName;
        public string ElementInfo;
        public int Position;
        public string Value;
        public ResultTypes ResultType;
        public string PAN;
    }

    public class PANandTracksSearch
    {
        Regex full_rgx;
        Regex pan_rgx;
        Regex test_rgx;

        private bool tracksOnly;

        public PANandTracksSearch(bool TracksOnly)
        {
            tracksOnly = TracksOnly;

            string pan_pattern = @"(?<![\d])(?:4[0-9]{12}|4[0-9]{3}\s?[0-9]{4}\s?[0-9]{4}\s?[0-9]{4}|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})(?![\d])";

            string track_pan_pattern = @"(?:4[0-9]{12}|4[0-9]{15}|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})";
            string track_main_pattern = @"(?:(?:\=[0-2][0-9][0-1][0-2]|\^.+\^[0-2][0-9][0-1][0-2]))";
            string full_track_pattern = track_pan_pattern + track_main_pattern;

            string test_pattern = @"(?:0{7}|1{7}|2{7}|3{7}|4{7}|5{7}|6{7}|7{7}|8{7}|9{7})";

            full_rgx = new Regex(full_track_pattern, RegexOptions.IgnoreCase);
            if (!tracksOnly)
                pan_rgx = new Regex(pan_pattern, RegexOptions.IgnoreCase);
            test_rgx = new Regex(test_pattern, RegexOptions.IgnoreCase);
        }

        public void Search(string input, string ElementInfo, string fName, ref List<SearchResult> res)
        {
            Search(input, ElementInfo, fName, ref res, full_rgx);
            if (!tracksOnly)
                Search(input, ElementInfo, fName, ref res, pan_rgx);
        }

        public void Search(string input, string ElementInfo, string fName, ref List<SearchResult> res, Regex regex)
        {
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                foreach (Group group in match.Groups)
                {
                    foreach (Capture capture in group.Captures)
                    {
                        SearchResult result = new SearchResult();

                        if (capture.Value.Contains("="))
                            result.ResultType = ResultTypes.Track2;
                        else
                            if (capture.Value.Contains("^"))
                            result.ResultType = ResultTypes.Track1;
                        else
                            result.ResultType = ResultTypes.PAN;

                        if (result.ResultType == ResultTypes.Track2)
                            result.PAN = capture.Value.Substring(0, capture.Value.IndexOf('='));
                        else
                            if (result.ResultType == ResultTypes.Track1)
                            result.PAN = capture.Value.Substring(0, capture.Value.IndexOf('^'));
                        else
                            result.PAN = capture.Value;

                        if (!PassesLuhnTest(result.PAN))
                            break;

                        MatchCollection test_matches = test_rgx.Matches(result.PAN);
                        if (test_matches.Count > 0)
                            break;

                        result.Value = capture.Value;
                        result.ElementInfo = ElementInfo;
                        result.Position = capture.Index;
                        result.FileName = fName;
                        res.Add(result);

                    }
                }
            }
        }

        public bool PassesLuhnTest(string cardNumber)
        {
            //Clean the card number- remove dashes and spaces
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");

            //Convert card number into digits array
            int[] digits = new int[cardNumber.Length];
            for (int len = 0; len < cardNumber.Length; len++)
            {
                digits[len] = Int32.Parse(cardNumber.Substring(len, 1));
            }

            //Luhn Algorithm
            int sum = 0;
            bool alt = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int curDigit = digits[i];
                if (alt)
                {
                    curDigit *= 2;
                    if (curDigit > 9)
                    {
                        curDigit -= 9;
                    }
                }
                sum += curDigit;
                alt = !alt;
            }

            //If Mod 10 equals 0, the number is good and this will return true
            return sum % 10 == 0;
        }
    }
}
