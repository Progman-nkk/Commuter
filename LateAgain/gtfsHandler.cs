using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using ProtoBuf;
using transit_realtime;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Text.RegularExpressions;

namespace LateAgain
{
    class gtfsHandler
    {
        //GTFS
        private static string apiKey = "348ce3ca0dfaa15a4f876657a37085dd";
        private static string[] dataFeedsCommon = new string[2] { "http://datamine.mta.info/mta_esi.php?key=", "&feed_id=" };
        private static string dataFeedsCommonFull = dataFeedsCommon[0] + apiKey + dataFeedsCommon[1];
        private void getLateTimes(string url)
        {
            WebRequest req = HttpWebRequest.Create(url);
            FeedMessage feed = Serializer.Deserialize<FeedMessage>(req.GetResponse().GetResponseStream());
            foreach (FeedEntity entity in feed.entity)
            {
                //var routeNumber = entity?.vehicle?.trip?.route_id;
                //if (routeNumber != null) { sharedMemory.Add(routeNumber); }
                var alternateInfo = entity?.alert;
                var routeId = entity?.trip_update?.trip?.route_id;
                //if (routeId != null && alternateInfo != null) { sharedMemory.Add(routeId.ToString() + ": " + alternateInfo.ToString() + "\n\n"); }
            }

        }
        private Dictionary<string, string> dataFeeds = new Dictionary<string, string>()
        {
            { "123456S", dataFeedsCommonFull + "1" },
            { "ACE", dataFeedsCommonFull + "26" },
            { "NQRW", dataFeedsCommonFull + "16" },
            { "BDFM", dataFeedsCommonFull + "21" },
            { "L", dataFeedsCommonFull + "2" },
            { "SIR", dataFeedsCommonFull + "11" },
            { "G", dataFeedsCommonFull + "31" },
            { "JZ", dataFeedsCommonFull + "36" },
            { "7", dataFeedsCommonFull + "51" }
        };
    }
}
