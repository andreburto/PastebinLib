using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace PastebinLib
{
    public class Pastebin
    {
        // Protected variables
        protected string _developer_api_key;
        protected string _user_key;
        // URL CONSTANTS
        protected const string _post_url = "http://pastebin.com/api/api_post.php";
        protected const string _login_url = "http://pastebin.com/api/api_login.php";
        protected const string _get_raw_url = "http://pastebin.com/raw.php";
        // Properties accessible to the public
        public string DeveloperApiKey
        {
            get { return _developer_api_key; }
            set { _developer_api_key = value; }
        }
        public string UserApiKey
        {
            get { return _user_key; }
            set { _user_key = value; }
        }
        // Gets a raw post
        public string GetPost(string key)
        {
            string url = String.Format("{0}?i={1}", _get_raw_url, key);
            string res = MakeGet(url);
            if (res.Length == 0) { return "ERROR: Nothing returned."; }
            return res;
        }
        // Makes a new post
        public string NewPaste(Hashtable args)
        {
            string retval;
            try
            {
                // If there's no code to paste throw an error
                if (args.ContainsKey("api_paste_code") == false)
                {
                    throw new Exception("Missing api_paste_code");
                }
                // You do not have to pass an api_dev_key but it must be set
                if (args.ContainsKey("api_dev_key") == false)
                {
                    if (_developer_api_key.Length == 0)
                    {
                        throw new Exception("api_dev_key");
                    }
                    else
                    {
                        args.Add("api_dev_key", _developer_api_key);
                    }
                }
                // Default to paste
                if (args.ContainsKey("api_option") == false)
                {
                    args.Add("api_option", "paste");
                }
                retval = MakePost(_post_url, args);
            }
            catch (Exception ex)
            {
                retval = String.Format("ERROR: (NewPaste) {0}", ex.Message);
            }
            return retval;
        }
        // Delete a Paste
        public string DeletePaste(Hashtable args)
        {
            string retval;
            try
            {
                // If there's no code to paste throw an error
                if (args.ContainsKey("api_paste_key") == false)
                {
                    throw new Exception("Missing api_paste_key");
                }
                // You do not have to pass an api_dev_key but it must be set
                if (args.ContainsKey("api_dev_key") == false)
                {
                    if (_developer_api_key.Length == 0)
                    {
                        throw new Exception("Missingapi_dev_key");
                    }
                    else
                    {
                        args.Add("api_dev_key", _developer_api_key);
                    }
                }
                // You do not have to pass an api_user_key but it must be set
                if (args.ContainsKey("api_user_key") == false)
                {
                    if (_user_key.Length == 0)
                    {
                        throw new Exception("Mising api_user_key");
                    }
                    else
                    {
                        args.Add("api_user_key", _user_key);
                    }
                }
                // Default to delete
                if (args.ContainsKey("api_option") == false)
                {
                    args.Add("api_option", "delete");
                }
                retval = MakePost(_post_url, args);
            }
            catch (Exception ex)
            {
                retval = String.Format("ERROR: (DeletePaste) {0}", ex.Message);
            }
            return retval;
        }
        // Get User info and settings 
        public string UserInfo(Hashtable args)
        {
            string retval;
            try
            {
                // You do not have to pass an api_dev_key but it must be set
                if (args.ContainsKey("api_dev_key") == false)
                {
                    if (_developer_api_key.Length == 0)
                    {
                        throw new Exception("Missingapi_dev_key");
                    }
                    else
                    {
                        args.Add("api_dev_key", _developer_api_key);
                    }
                }
                // You do not have to pass an api_user_key but it must be set
                if (args.ContainsKey("api_user_key") == false)
                {
                    if (_user_key.Length == 0)
                    {
                        throw new Exception("Mising api_user_key");
                    }
                    else
                    {
                        args.Add("api_user_key", _user_key);
                    }
                }
                // Default to delete
                if (args.ContainsKey("api_option") == false)
                {
                    args.Add("api_option", "userdetails");
                }
                retval = MakePost(_post_url, args);
            }
            catch (Exception ex)
            {
                retval = String.Format("ERROR: (UserInfo) {0}", ex.Message);
            }
            return retval;
        }
        // List Trending Pastes
        public string TrendingPastes(Hashtable args)
        {
            string retval;
            try
            {
                // You do not have to pass an api_dev_key but it must be set
                if (args.ContainsKey("api_dev_key") == false)
                {
                    if (_developer_api_key.Length == 0)
                    {
                        throw new Exception("Missingapi_dev_key");
                    }
                    else
                    {
                        args.Add("api_dev_key", _developer_api_key);
                    }
                }
                // Default to trends
                if (args.ContainsKey("api_option") == false)
                {
                    args.Add("api_option", "trends");
                }
                retval = MakePost(_post_url, args);
            }
            catch (Exception ex)
            {
                retval = String.Format("ERROR: (TrendingPastes) {0}", ex.Message);
            }
            return retval;
        }
        // List User Pastes
        public string ListUserPastes(Hashtable args)
        {
            string retval;
            try
            {
                // You do not have to pass an api_dev_key but it must be set
                if (args.ContainsKey("api_dev_key") == false)
                {
                    if (_developer_api_key.Length == 0)
                    {
                        throw new Exception("Missingapi_dev_key");
                    }
                    else
                    {
                        args.Add("api_dev_key", _developer_api_key);
                    }
                }
                // You do not have to pass an api_user_key but it must be set
                if (args.ContainsKey("api_user_key") == false)
                {
                    if (_user_key.Length == 0)
                    {
                        throw new Exception("Mising api_user_key");
                    }
                    else
                    {
                        args.Add("api_user_key", _user_key);
                    }
                }
                // Make sure maximum api_results_limit is under 1000
                if (args.ContainsKey("api_results_limit") == true)
                {
                    int limit = Int16.Parse(args["api_results_limit"].ToString());
                    if (limit > 1000) { args["api_results_limit"] = "1000"; }
                }
                // Default to delete
                if (args.ContainsKey("api_option") == false)
                {
                    args.Add("api_option", "list");
                }
                retval = MakePost(_post_url, args);
            }
            catch (Exception ex)
            {
                retval = String.Format("ERROR: (ListUserInfo) {0}", ex.Message);
            }
            return retval;
        }
        // Get the UserApiKey
        public string UserKey(Hashtable args)
        {
            string retval;
            try
            {
                // Check for userid
                if (args.ContainsKey("api_user_name") == false)
                {
                    throw new Exception("No api_user_name");
                }
                // Check for password
                if (args.ContainsKey("api_user_password") == false)
                {
                    throw new Exception("No api_user_password");
                }
                // You do not have to pass an api_dev_key but it must be set
                if (args.ContainsKey("api_dev_key") == false)
                {
                    if (_developer_api_key.Length == 0)
                    {
                        throw new Exception("api_dev_key");
                    }
                    else
                    {
                        args.Add("api_dev_key", _developer_api_key);
                    }
                }
                retval = MakePost(_login_url, args);
                // Go on and assign the local variable if we get this far
                if (retval.Length > 0) { _user_key = retval; }
            }
            catch (Exception ex)
            {
                retval = String.Format("ERROR: (UserKey) {0}", ex.Message);
            }
            return retval;
        }
        // Compresses a Hashtable into a POST data string
        protected string MakeDataString(Hashtable h)
        {
            ArrayList temp = new ArrayList();
            foreach (string k in h.Keys)
            {
                temp.Add(String.Format("{0}={1}", k, HttpUtility.UrlEncode(h[k].ToString())));
            }
            return String.Join("&", (string[])temp.ToArray(typeof(string)));
        }
        // Handles the POST requests
        protected string MakePost(string url, Hashtable args)
        {
            string retval = "";
            string data = MakeDataString(args);

            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Encoding = Encoding.UTF8;

            try
            {
                byte[] result = wc.UploadData(url, "POST", Encoding.UTF8.GetBytes(data));
                retval = Encoding.UTF8.GetString(result);
            }
            catch (WebException we)
            {
                retval = String.Format("ERROR: WEB EXCEPTION (MakeGet) {0}", we.Message);
            }
            catch (Exception ex)
            {
                retval = String.Format("ERROR: EXCEPTION (MakeGet) {0}", ex.Message);
            }
            finally
            {
                wc.Dispose();
            }
            return retval;
        }
        // Handles GET requests
        protected string MakeGet(string url)
        {
            string retval = "";

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            try
            {
                retval = wc.DownloadString(url);
                wc.Dispose();
            }
            catch (WebException we)
            {
                retval = String.Format("ERROR: WEB EXCEPTION (MakeGet) {0}", we.Message);
            }
            catch (Exception ex)
            {
                retval = String.Format("ERROR: EXCEPTION (MakeGet) {0}", ex.Message);
            }
            finally
            {
                wc.Dispose();
            }
            return retval;
        }
        // CONSTRUCTORS: No arguments
        public Pastebin() { }
        // With one argument: DeveloperApiKey
        public Pastebin(string dak) { _developer_api_key = dak; }
        // With two arguments: DeveloperApiKey, UserApiKey
        public Pastebin(string dak, string uak) { _developer_api_key = dak; _user_key = uak; }
    }
    // Pastebin class functions often take Hashtabe arguments.
    // PastebinAtgs will accept arguments and then output them as a Hashtable.
    public class PastebinArgs
    {
        // PRIVATE hashtable where values are stored
        private Hashtable ht;
        // PUBLIC string properties to set and get API arguments
        public string api_dev_key
        {
            get { return GetVal("api_dev_key"); }
            set { ht["api_dev_key"] = value; }
        }
        public string api_option
        {
            get { return GetVal("api_option"); }
            set { ht["api_option"] = value; }
        }
        public string api_paste_code
        {
            get { return GetVal("api_paste_code"); }
            set { ht["api_paste_code"] = value; }
        }
        public string api_paste_expire_date
        {
            get { return GetVal("api_paste_expire_date"); }
            set { ht["api_paste_expire_date"] = value; }
        }
        public string api_paste_format
        {
            get { return GetVal("api_paste_format"); }
            set { ht["api_paste_format"] = value; }
        }
        public string api_paste_key
        {
            get { return GetVal("api_paste_key"); }
            set { ht["api_paste_key"] = value; }
        }
        public string api_paste_name
        {
            get { return GetVal("api_paste_name"); }
            set { ht["api_paste_name"] = value; }
        }
        public string api_paste_private
        {
            get { return GetVal("api_paste_private"); }
            set { ht["api_paste_private"] = value; }
        }
        public string api_results_limit
        {
            get { return GetVal("api_results_limit"); }
            set { ht["api_results_limit"] = value; }
        }
        public string api_user_key
        {
            get { return GetVal("api_user_key"); }
            set { ht["api_user_key"] = value; }
        }
        public string api_user_name
        {
            get { return GetVal("api_user_name"); }
            set { ht["api_user_name"] = value; }
        }
        public string api_user_password
        {
            get { return GetVal("api_user_password"); }
            set { ht["api_user_password"] = value; }
        }
        public string paste_key
        {
            get { return GetVal("paste_key"); }
            set { ht["paste_key"] = value; }
        }
        // Returns the key is it exists
        private string GetVal(string key)
        {
            return ht.ContainsKey(key) ? ht[key].ToString() : "";
        }
        // Return the hash, a function to match ToString
        public Hashtable ToHashtable() { return ht; }
        // Display all set keys
        public override string ToString()
        {
            string temp = "";
            if (ht.Keys.Count > 0)
            {
                foreach (string key in ht.Keys.Cast<string>().OrderBy(c => c))
                {
                    temp += String.Format("{0} = {1}\r\n", key, ht[key].ToString());
                }
            }
            else
            {
                temp = "No keys set.";
            }
            return temp;
        }
        // CONSTRUCTOR
        public PastebinArgs() { ht = new Hashtable(); }
    }
    // Pastebin language options
    public static class PastebinOptions
    {
        // PRIVATE CONSTANTS
        static private string LANGUAGES = "PastebinLib.Languages.txt";
        static private string PRIVACY = "PastebinLib.Privacy.txt";
        static private string EXPIRES = "PastebinLib.Expires.txt";
        // PUBLIC READ-ONLY PROPERTIES
        static public PastebinOption[] Languages { get { return LoadOptions(LANGUAGES); } }
        static public PastebinOption[] Privacy { get { return LoadOptions(PRIVACY); } }
        static public PastebinOption[] Expires { get { return LoadOptions(EXPIRES); } }
        // Fetch the results
        static private PastebinOption[] LoadOptions(string choice)
        {
            string bulk_read = "";
            string[] rows_read;
            List<PastebinOption> values = new List<PastebinOption>();
            // Read the embedded file
            Assembly a = Assembly.GetExecutingAssembly();
            StreamReader sr = new StreamReader(a.GetManifestResourceStream(choice));
            bulk_read = sr.ReadToEnd();
            rows_read = bulk_read.Replace("\n", "").Split('\r');
            if (rows_read.Length > 0)
            {
                foreach (string row in rows_read)
                {
                    string[] parts = row.Split('=');
                    values.Add(new PastebinOption(parts[0], parts[1]));
                }
            }
            values.Sort();
            return values.ToArray<PastebinOption>();
        }
    }
    // PastebinOption object for sorting
    public class PastebinOption : IComparable<PastebinOption>
    {
        public string Key;
        public string Val;

        public int CompareTo(PastebinOption other)
        {
            if (this.Val == other.Val)
            {
                return this.Key.CompareTo(other.Key);
            }
            return this.Val.CompareTo(other.Val);
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", this.Val, this.Key);
        }

        public PastebinOption(string k, string v)
        {
            this.Key = k;
            this.Val = v;
        }
    }
}