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
using System.Diagnostics;

namespace LateAgain
{
    public class Railroad
    {
        public Stopwatch xmlFetcher;
        private List<TrainData> trainStation;
        private string destinationUrl = "http://web.mta.info/status/ServiceStatusSubway.xml";
        public int trainToDisplay = 0;
        public List<TrainData> TrainStation
        {
            get
            {
                return trainStation;
            }

            set
            {
                trainStation = value;
            }
        }

        public string DestinationUrl
        {
            get
            {
                return destinationUrl;
            }

            set
            {
                destinationUrl = value;
            }
        }

        public void parseXML(string destinationURL)
        {
            if(!xmlFetcher.IsRunning) { xmlFetcher.Start();  }
            //XmlNodeList situationNodes = getXMLData(destinationUrl).GetElementsByTagName("PtSituationElement");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(destinationURL);
            TrainStation.Clear();

            XmlNodeList situationNodes = xmlDoc.GetElementsByTagName("PtSituationElement");
            if (situationNodes.Count > 0)
            {
                XmlNamespaceManager ns = new XmlNamespaceManager(xmlDoc.NameTable);
                ns.AddNamespace("siri", "http://www.siri.org.uk/siri");
                foreach (XmlNode situationElement in situationNodes)
                {
                    string tempSummary = situationElement.SelectSingleNode("descendant::siri:Summary", ns).InnerText;
                    string tempReason = situationElement.SelectSingleNode("descendant::siri:ReasonName", ns).InnerText;
                    string tempPriority = situationElement.SelectSingleNode("descendant::siri:MessagePriority", ns).InnerText;
                    string tempSource = situationElement.SelectSingleNode("descendant::siri:Source/siri:SourceType", ns).InnerText;
                    string tempId = situationElement.SelectSingleNode("descendant::siri:SituationNumber", ns).InnerText;
                    tempId = parseId(tempId);
                    List<Tuple<string, string>> tempAffectedLines = new List<Tuple<string, string>>();
                    XmlNodeList affectedLines = situationElement.SelectNodes("descendant::siri:AffectedVehicleJourney", ns);
                    foreach (XmlNode node in affectedLines)
                    {
                        string line = node.SelectSingleNode("descendant::siri:LineRef", ns).InnerText;
                        string direction = node.SelectSingleNode("descendant::siri:DirectionRef", ns).InnerText;

                        tempAffectedLines.Add(parseAffectedLines(Tuple.Create(line, direction)));
                    }

                    List<Tuple<string, string>> tempConsequences = new List<Tuple<string, string>>();
                    XmlNodeList consequenceNodes = situationElement.SelectNodes("descendant::siri:Consequence", ns);
                    foreach (XmlNode node in consequenceNodes)
                    {
                        string condition = node.SelectSingleNode("descendant::siri:Condition", ns).InnerText;
                        string severity = node.SelectSingleNode("descendant::siri:Severity", ns).InnerText;
                        tempConsequences.Add(Tuple.Create(condition, severity));
                    }


                    TrainData tempTrainData = new TrainData(tempSummary, tempReason, tempPriority, tempSource, tempAffectedLines, tempConsequences, tempId);
                    bool isInStation = false;
                    foreach (TrainData train in TrainStation)
                    {
                        if (train.Id == tempTrainData.Id)
                        {
                            isInStation = true;
                            train.isDisplayed = false;
                            
                        }
                    }
                    if (!isInStation) { TrainStation.Add(tempTrainData); }

                }
            }
        }
        private string parseId(string _tempId)
        {
            Regex _regex = new Regex(@"_");
            string[] result = new string[2];
            foreach (Match m in Regex.Matches(_tempId, @"NYCT_.*"))
            {
                result = _regex.Split(m.Value);
            }

            return result[1];
        }
        private Tuple<string, string> parseAffectedLines(Tuple<string, string> affectedLine)
        {
            Regex _regex = new Regex(@"_");
            string[] result = new string[2];
            foreach (Match m in Regex.Matches(affectedLine.Item1, @"NYCT_.*"))
            {
                result = _regex.Split(m.Value);
            }
            string direction;
            if (affectedLine.Item2 == "0") { direction = "Northbound"; } else { direction = "Southbound"; }
            return Tuple.Create(result[1], direction); ;
        }
        public Railroad()
        {
            xmlFetcher = new Stopwatch();
            TrainStation = new List<TrainData>();
        }

        public class TrainData
        {
            public bool isDisplayed = false;
            private string summary, reason, priority, source, id = "0";
            private List<Tuple<string, string>> affectedLines;
            private List<Tuple<string, string>> consequences;
            public TrainData(string _summary, string _reason, string _priority, string _source, List<Tuple<string, string>> _affectedLines, List<Tuple<string, string>> _consequences, string _id)
            {
                Summary = _summary;
                Reason = _reason;
                Priority = _priority;
                Source = _source;
                Id = _id;
                AffectedLines = new List<Tuple<string, string>>(_affectedLines);
                Consequences = new List<Tuple<string, string>>(_consequences);
            }

            public string Summary
            {
                get
                {
                    return summary;
                }

                set
                {
                    summary = value;
                }
            }
            public string Reason
            {
                get
                {
                    return reason;
                }

                set
                {
                    reason = value;
                }
            }
            public string Priority
            {
                get
                {
                    return priority;
                }

                set
                {
                    priority = value;
                }
            }
            public string Source
            {
                get
                {
                    return source;
                }

                set
                {
                    source = value;
                }
            }
            public List<Tuple<string, string>> AffectedLines
            {
                get
                {
                    return affectedLines;
                }

                set
                {

                    affectedLines = value;
                }
            }
            public List<Tuple<string, string>> Consequences
            {
                get
                {
                    return consequences;
                }

                set
                {
                    consequences = value;
                }
            }
            public string Id
            {
                get
                {
                    return id;
                }

                set
                {
                    id = value;
                }
            }
        }

    }
}
