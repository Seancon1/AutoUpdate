using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionControl_AutoUpdate.AutoUpdate
{
    class FetchUpdateVersion
    {

        public double newVersionNumber;

        public FetchUpdateVersion()
        {

        }

        /**
         * Connects to the online version number
         * returns the result
         * */
        public double GetVersion()
        {
            string result = null;
            double returnVersion;
            var myClient = new WebClient();
            Stream response = myClient.OpenRead("https://www.prestigecode.com/projects/autoupdate/version/");
            // The stream data is used here.
            StreamReader streamReader = new StreamReader(response);

            result = streamReader.ReadLine();
            response.Close();

            double.TryParse(result, out returnVersion);
            StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder
            this.newVersionNumber = returnVersion;//set class public int to this as well
            return returnVersion;
        }
    }
}
