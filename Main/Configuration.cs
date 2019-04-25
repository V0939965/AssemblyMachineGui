using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Main
{
    class Configuration
    {
        public data Parameter = new data();
        public StringInput save = new StringInput();
        private string add = "mongodb://localhost:27017";
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<BsonDocument> Config;
        public bool Init()
        {
            try
            {
                client = new MongoClient(new MongoUrl(add));
                db = client.GetDatabase("AssemblyMachine");
                Config = db.GetCollection<BsonDocument>("Configuration");
                bool kq = ReadData("Title", "Configuration");
                if (kq == true)
                {
                    kq = Update();
                    if (kq == true)
                        return true;
                    else
                        return false;
                } 
                else
                    return false;
            }
            catch(MongoClientException er)
            {
                DialogResult kq =  MessageBox.Show(er.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if(kq == DialogResult.Retry)
                {
                    Init();
                }
            }
            return false;
            
        }

        private bool ReadData(string FilterKey, string FilterValue)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq(FilterKey, FilterValue);
            var doc = Config.Find(filter).ToList();
            foreach (var item in doc)
            {
                save.ExposureTime = item["ExposureTime"].AsString;
                save.LabelSize = item["LabelSize"].AsString;
                save.LightValue = item["LightValue"].AsString;
                save.PulseX = item["PulseX"].AsString;
                save.PulseY = item["PulseY"].AsString;
                save.PulseZ = item["PulseZ"].AsString;
                save.Roi = item["Roi"].AsString;
                save.RotationCenter = item["RotationCenter"].AsString;
                save.ThresholdValue = item["ThresholdValue"].AsString;
                return true;
            }
            return false;
        }
        private bool WriteData(string WriteKey, string WriteValue)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("Title", "Configuration");
            var update = Builders<BsonDocument>.Update.Set(WriteKey, WriteValue);
            UpdateResult result = Config.UpdateOne(filter, update);
            return result.IsAcknowledged;
        }
        public bool Update(string exposuretime = null,
                            string threshold = null,
                            string roi = null,
                            string pulsex = null,
                            string pulsey = null,
                            string pulsez = null,
                            string Center = null,
                            string Lightvalue = null)
        {
            if (exposuretime == null)
                exposuretime = save.ExposureTime;
            if (threshold == null)
                threshold = save.ThresholdValue;
            if (roi == null)
                roi = save.Roi;
            if (pulsex == null)
                pulsex = save.PulseX;
            if (pulsey == null)
                pulsey = save.PulseY;
            if (pulsez == null)
                pulsez = save.PulseZ;
            if (Lightvalue == null)
                Lightvalue = save.LightValue;
            if (Center == null)
                Center = save.RotationCenter;

            try
            {
                Parameter.THRESHOLD_VALUE = Convert.ToInt16(threshold);
                Parameter.EXPOSURE_TIME = Convert.ToInt16(exposuretime);
                Parameter.PULSE_X = Convert.ToInt32(pulsex);
                Parameter.PULSE_Y = Convert.ToInt32(pulsey);
                Parameter.PULSE_Z = Convert.ToInt32(pulsez);
                string split = null;
                int count = 1;
                for (int i = 0; i < roi.Length; i++)
                {
                    char item = roi[i];
                    if (item.ToString() == "," || i == roi.Length - 1)
                    {
                        switch (count)
                        {
                            case 1:
                                {
                                    Parameter.ROI.X = Convert.ToInt16(split);
                                    break;
                                }
                            case 2:
                                {
                                    Parameter.ROI.Y = Convert.ToInt16(split);
                                    break;
                                }
                            case 3:
                                {
                                    Parameter.ROI.Width = Convert.ToInt16(split);
                                    break;
                                }
                            default:
                                {
                                    split += item.ToString();
                                    Parameter.ROI.Height = Convert.ToInt16(split);
                                    break;
                                }
                        }
                        count++;
                        split = null;
                    }
                    else
                    {
                        split += item.ToString();
                    }
                }
                count = 1;
                for (int i = 0; i < Center.Length; i++)
                {
                    if (Center[i].ToString() == "," || i == Center.Length - 1)
                    {
                        switch (count)
                        {
                            case 1:
                                {
                                    Parameter.ROTATION_CENTER.X = Convert.ToInt16(split);
                                    Parameter.ROTATION_CENTER.X -= Parameter.ROI.X;
                                    break;
                                }
                            default:
                                {
                                    split += Center[i].ToString();
                                    Parameter.ROTATION_CENTER.Y = Convert.ToInt16(split);
                                    Parameter.ROTATION_CENTER.Y -= Parameter.ROI.Y;
                                    break;
                                }
                        }
                        count++;
                        split = null;
                    }
                    else
                        split += Center[i].ToString();
                }
                Parameter.LabelSize = new Rectangle(0, 0, 50, 20);
                Parameter.LightValue = Convert.ToInt32(Lightvalue);
                WriteData("ExposureTime", exposuretime.ToString());
                WriteData("LabelSize", save.LabelSize);
                WriteData("LightValue",Lightvalue.ToString());
                WriteData("PulseX", pulsex.ToString());
                WriteData("PulseY", pulsey.ToString());
                WriteData("PulseZ", pulsez.ToString());
                WriteData("Roi", roi.ToString());
                WriteData("RotationCenter", Center.ToString());
                WriteData("ThresholdValue", threshold.ToString());
                ReadData("Title", "Configuration");
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    struct StringInput
    {
        public string ExposureTime, ThresholdValue, Roi, RotationCenter, PulseX, PulseY, PulseZ, LightValue, LabelSize;
    }

    struct data
    {
        public int THRESHOLD_VALUE;
        public Rectangle ROI;
        public int EXPOSURE_TIME;
        public int PULSE_X;
        public int PULSE_Y;
        public int PULSE_Z;
        public Rectangle LabelSize;
        public Point ROTATION_CENTER;
        public int LightValue;
    }
}