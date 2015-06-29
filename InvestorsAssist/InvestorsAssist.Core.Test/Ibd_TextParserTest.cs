﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestorsAssist.Core;

namespace InvestorsAssist.Core.Test
{
    [TestClass]
    public class Ibd_TextParserTest
    {
        [TestMethod]
        public void Ibd_TextParser_ParseDateLine_ShouldParseCorrectLine()
        {
            const string line = @"Screen results as of 9:55 PM Eastern, Thursday, June 04, 2015";
            DateTime? value = IbdParser.ParseDateLine(line);
            Assert.IsTrue(value != null);
            Assert.IsTrue(value.Value == new DateTime(2015, 6, 4));
        }

        [TestMethod]
        public void Ibd_TextParser_ParseIbdPickLine_ShouldParseCorrectLine()
        {
            const string guide = @"------     ------------------------     -----------     -------------     ------------     --------------     ----------     ------------     ------------     ----------------     ----------     ---------     ----------     --------------     --------------------     --------------------     --------------------     ---------------------------     --------------------------     ----------------------     ----------------------     --------------------------------     ----------     --------------------------     ";
            const string line = @"AMCX       Amc Networks Inc             38              79.6000           0.8900           1.13               -2.99          369.1            46               89                   99             84            N/A            B-                 A-                       69                       125                      0                               21                             27                         N/A                        19.7                                 2              1                              ";
            var value = IbdParser.ParseIbdPickLine(guide, line);
            Assert.IsTrue(value != null);
        }
        [TestMethod]
        public void Ibd_TextParser_Parse_Should_ParseCorrectText()
        {
            var idbPicks = IbdParser.Parse(_correctText);
            Assert.IsTrue(idbPicks.Count == 50);
        }

        
        private string _correctText =
@"Screen Center: IBD 50

Description: The IBD 50 is a list of 50 top-rated growth stocks in IBD's database with top fundamentals showing strong relative price strength in the market.

Export Date: 3:44 PM Eastern, Friday, June 05, 2015

Symbol     Company Name                 IBD 50 Rank     Current Price     Price Change     Price % Change     % Off High     Volume (000)     Volume % Chg     Composite Rating     EPS Rating     RS Rating     SMR Rating     Acc/Dis Rating     Group Rel Str Rating     EPS % Chg (Last Qtr)     EPS % Chg (Prev Qtr)     EPS Est % Chg (Current Qtr)     EPS Est % Chg (Current Yr)     Sales % Chg (Last Qtr)     Annual ROE (Latest Yr)     Annual Profit Margin (Latest Yr)     Mgmt Own %     Qtrs of Rising Sponsorship     
------     ------------------------     -----------     -------------     ------------     --------------     ----------     ------------     ------------     ----------------     ----------     ---------     ----------     --------------     --------------------     --------------------     --------------------     ---------------------------     --------------------------     ----------------------     ----------------------     --------------------------------     ----------     --------------------------     
AMBA       Ambarella Inc                1               103.2300          2.8600           2.85               1.30           4082.5           164              99                   99             99            A              A                  A+                       184                      162                      111                             50                             74                         32.7                       31.0                                 9              1                              
SWKS       Skyworks Solutions Inc       2               105.6000          -0.0200          -0.02              -5.36          3649.3           78               99                   99             97            A              B                  A-                       85                       88                       54                              58                             58                         26.9                       30.0                                 1              5                              
CYBR       Cyberark Software Ltd        3               65.6800           4.0100           6.50               -12.50         1166.3           154              99                   99             97            A              C                  A+                       1500                     200                      -25                             -12                            89                         15.8                       19.7                                 64             1                              
ELLI       Ellie Mae Inc                4               65.2700           1.4000           2.19               -4.67          311.7            98               99                   99             98            A              B                  A+                       106                      100                      0                               -2                             68                         14.8                       25.3                                 7              3                              
PAYC       Paycom Software Inc          5               35.4800           0.2500           0.71               -11.37         317.8            81               99                   99             97            A              B+                 A                        300                      400                      50                              61                             49                         24.0                       10.9                                 29             3                              
AVGO       Avago Technologies Ltd       6               143.8600          2.6600           1.88               -6.18          2793.5           101              99                   98             96            A              B                  A+                       151                      149                      70                              77                             130                        43.8                       33.4                                 1              8                              
MANH       Manhattan Associates Inc     7               56.9400           1.8600           3.38               -8.17          347.3            171              99                   97             96            A              B-                 A                        31                       25                       14                              16                             18                         48.5                       28.0                                 1              8                              
VRX        Valeant Pharmaceuticals      8               235.3000          2.4200           1.04               -5.34          1341.8           52               99                   96             97            A              A-                 A+                       34                       20                       29                              34                             16                         54.6                       35.7                                 4              4                              
ULTA       Ulta Salon Cosm & Frag       9               155.9400          0.0400           0.03               -2.47          816.5            60               97                   96             94            A              B                  B+                       35                       22                       19                              19                             22                         22.7                       12.7                                 2              4                              
VDSI       Vasco Data Security Intl     10              28.4800           0.4900           1.75               -12.09         2554.1           117              99                   97             97            A              B+                 A+                       200                      167                      33                              6                              68                         20.4                       22.7                                 23             5                              
GTN        Gray Television Inc          11              15.7000           0.1700           1.09               -6.84          1085.7           47               97                   97             96            A              A+                 B-                       400                      489                      333                             -37                            46                         24.6                       15.7                                 2              1                              
EPAM       Epam Systems Inc             12              71.5100           0.2600           0.36               -2.90          262.4            52               99                   95             96            A              B                  A-                       30                       29                       21                              22                             25                         26.3                       17.5                                 7              8                              
UVE        Universal Insurance Hldg     13              25.5200           -0.3800          -1.47              -6.60          194.1            53               96                   95             96            A              B-                 C                        63                       34                       12                              14                             40                         38.9                       34.6                                 11             8                              
CRTO       Criteo SA Ads                14              50.9800           1.2900           2.60               -0.92          654.4            86               97                   98             91            A              A+                 B+                       88                       150                      -39                             0                              35                         19.9                       6.3                                  16             3                              
OZRK       Bank Of The Ozarks Inc       15              45.6000           0.7800           1.74               -1.78          422.1            81               98                   97             93            A              A-                 B                        55                       30                       46                              36                             N/A                        15.3                       45.7                                 10             3                              
SYNA       Synaptics Inc                16              100.4700          1.7100           1.73               -2.73          524.1            37               99                   96             94            A              B+                 A                        162                      70                       14                              37                             134                        25.8                       20.0                                 5              1                              
REGN       Regeneron Pharmaceutical     17              538.6700          20.0500          3.87               -0.16          815.4            111              99                   94             94            A              B                  A+                       27                       25                       11                              11                             39                         52.3                       41.7                                 10             8                              
ZBRA       Zebra Tech Corp Cl A         18              114.0400          0.5700           0.50               -1.51          274.2            56               99                   94             95            A              A                  A                        45                       20                       40                              51                             210                        19.9                       15.1                                 5              3                              
MTSI       M/A-COM Technology Sltn      19              40.3600           -0.1100          -0.27              -0.22          375.3            30               99                   92             97            A              B+                 A-                       28                       52                       21                              30                             16                         25.4                       17.0                                 52             4                              
PNK        Pinnacle Entertainment       20              36.9500           0.6100           1.68               -10.09         430.6            52               96                   92             95            A              A-                 A-                       18                       29                       0                               6                              8                          35.1                       5.2                                  6              3                              
BSFT       Broadsoft Inc                21              37.9000           0.0900           0.24               -1.66          173.4            31               99                   92             96            A              A-                 A                        243                      42                       0                               16                             27                         19.2                       19.0                                 2              3                              
CRUS       Cirrus Logic Inc             22              35.6000           -1.5100          -4.07              -2.85          695.1            112              99                   91             97            A              A-                 A+                       61                       9                        16                              -10                            71                         25.0                       19.5                                 3              1                              
TASR       T A S E R International      23              32.1500           0.7900           2.52               -10.40         1663.8           69               97                   91             98            A              B                  B+                       117                      -10                      29                              30                             24                         16.8                       19.6                                 5              0                              
IPGP       I P G Photonics Corp         24              98.3100           0.7200           0.74               -4.78          215.4            34               94                   97             90            A              C-                 B-                       40                       53                       21                              18                             17                         20.3                       37.0                                 34             3                              
PBH        Prestige Brands Holdings     25              44.0800           0.4600           1.05               -3.67          325.7            57               98                   97             90            A              B-                 A+                       34                       60                       22                              15                             33                         16.5                       21.4                                 1              3                              
MEI        Methode Electronics Inc      26              47.8700           0.3100           0.65               -2.94          205.3            66               93                   96             93            A              B+                 C+                       79                       29                       -46                             3                              9                          28.3                       9.8                                  5              3                              
ABC        Amerisourcebergen Corp       27              111.4100          -0.0800          -0.07              -7.62          1560.5           53               94                   95             91            A              B-                 B-                       37                       43                       14                              24                             15                         43.2                       1.2                                  7              4                              
AOS        Smith A O Corp               28              71.4500           -0.0100          -0.01              -1.64          187.9            37               97                   94             92            B              B+                 A                        20                       23                       0                               15                             12                         16.3                       13.1                                 2              3                              
NTES       Netease Inc Adr              29              145.4850          2.3050           1.61               -4.74          779.3            170              99                   89             97            A              A-                 A+                       20                       9                        16                              18                             55                         22.4                       48.2                                 45             3                              
OUTR       Outerwall Inc                30              76.9400           1.0300           1.36               -4.53          242.5            61               96                   99             83            C              B-                 A+                       102                      45                       15                              26                             2                          44.4                       9.3                                  1              2                              
ORLY       O Reilly Automotive Inc      31              221.9600          -0.1600          -0.07              -3.75          432.6            37               97                   96             90            A              B-                 B+                       28                       26                       18                              19                             10                         39.1                       16.9                                 4              5                              
WAL        Western Alliance Bancorp     32              33.2600           0.7600           2.34               -1.19          692.6            97               95                   95             90            A              B                  B                        29                       24                       12                              10                             13                         16.0                       44.3                                 14             5                              
ACT        Actavis plc                  33              302.0300          -1.3500          -0.44              -4.51          1697.1           47               99                   95             87            A              A                  A+                       23                       23                       29                              28                             59                         16.4                       28.4                                 0              8                              
UHS        Universal Health Svcs B      34              127.3400          0.1100           0.09               -3.64          523.4            51               98                   95             87            B              B-                 A+                       31                       47                       5                               14                             15                         16.7                       11.4                                 12             8                              
SC         Santander Cons USA Hldgs     35              24.5550           -0.0050          -0.02              -3.84          2607.1           35               99                   93             89            A              A-                 A                        252                      116                      6                               26                             21                         24.6                       19.8                                 10             1                              
PZZA       Papa Johns Intl Inc          36              69.2800           1.2300           1.81               -2.70          292              65               93                   92             94            A              B-                 B                        22                       27                       23                              18                             8                          65.5                       7.1                                  28             6                              
NOAH       Noah Holdings Ltd Ads        37              34.9700           0.7900           2.31               -9.96          419.9            43               94                   89             98            A              B-                 B-                       19                       4                        -2                              17                             43                         29.7                       41.5                                 46             1                              
AMCX       Amc Networks Inc             38              79.6000           0.8900           1.13               -2.99          369.1            46               89                   99             84            N/A            B-                 A-                       69                       125                      0                               21                             27                         N/A                        19.7                                 2              1                              
ATHM       Autohome Inc Cl A Ads        39              46.2000           1.1100           2.46               -22.16         1296.8           91               93                   99             79            A              C+                 B+                       40                       81                       29                              35                             82                         27.4                       45.9                                 19             3                              
GILD       Gilead Sciences Inc          40              113.8100          -0.1200          -0.11              -2.48          8527.4           55               99                   98             83            A              B-                 A+                       99                       342                      12                              33                             52                         99.4                       65.0                                 2              8                              
AAPL       Apple Inc                    41              128.7200          -0.6400          -0.49              -3.85          38242.5          63               94                   96             84            A              D-                 A                        40                       48                       36                              40                             27                         33.6                       29.3                                 0              4                              
SPR        Spirit Aerosystems Hldgs     42              55.3500           0.3400           0.62               -2.12          886.7            66               92                   92             94            A              B+                 B-                       18                       34                       -1                              8                              1                          32.8                       10.8                                 0              6                              
MSCC       Microsemi Corp               43              36.1600           0.3100           0.86               -4.17          315.9            31               94                   92             90            A              A                  A-                       31                       41                       19                              25                             3                          19.3                       19.5                                 2              1                              
KMX        Carmax Inc                   44              73.6200           0.5300           0.73               -3.06          1285.2           61               96                   92             92            B              B+                 B                        52                       28                       13                              11                             14                         18.5                       6.8                                  2              4                              
SCI        Service Corp Intl            45              29.2100           0.1000           0.34               -1.39          433.2            28               93                   90             91            A              B+                 A-                       14                       33                       13                              12                             0                          16.5                       15.1                                 7              2                              
CALM       Cal-Maine Foods Inc          46              56.0700           -0.5000          -0.88              -6.83          792.4            50               92                   87             96            B              A-                 C                        18                       41                       46                              47                             11                         19.7                       11.2                                 2              6                              
CMCM       Cheetah Mobile Cl A Ads      47              34.8200           1.7200           5.20               -9.64          854.9            99               99                   82             98            A              A+                 A+                       80                       150                      -75                             -41                            113                        20.5                       15.0                                 25             0                              
BIIB       Biogen Inc                   48              388.2300          3.8900           1.01               -19.96         1524.9           43               96                   98             71            A              D+                 A+                       55                       75                       16                              21                             20                         33.8                       45.6                                 0              8                              
HZNP       Horizon Pharma Plc           49              32.1900           0.8800           2.81               -5.09          2207.5           47               98                   75             99            A              B+                 A+                       62                       1450                     33                              38                             118                        37.7                       29.1                                 2              2                              
TSM        Taiwan Semiconductor Adr     50              22.8350           -0.1450          -0.63              -10.83         16931.4          51               97                   95             64            A              B-                 A-                       63                       69                       13                              11                             46                         29.3                       27.9                                 1              5                              
Screen results as of 9:55 PM Eastern, Thursday, June 04, 2015

Data provided by William O'Neil + Co., Inc. (c) 2015. All Rights Reserved.
Investor's Business Daily is a registered trademark of Investor's Business Daily, Inc.
Reproduction or redistribution other than for personal non-commercial use is prohibited.
All prices are delayed at least 20 minutes.";
    }
}
