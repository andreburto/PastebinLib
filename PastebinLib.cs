using System;
using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.Text;
namespace PastebinLib
{
    class Pastebin
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
            if (res.Length == 0) { return "Nothing returned."; }
            return res;
        }
        // Makes a new post
        public string NewPost(Hashtable args)
        {
            NameValueCollection vals = new NameValueCollection();
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
                        vals.Add("api_dev_key", _developer_api_key);
                    }
                }
                else
                {
                    vals.Add("api_dev_key", args["api_dev_key"].ToString());
                }
                // Default to paste
                if (args.ContainsKey("api_option") == false)
                {
                    vals.Add("api_option", "paste");
                }
                else
                {
                    vals.Add("api_option", args["api_option"].ToString());
                }
                retval = MakePost(_post_url, vals);
            }
            catch (Exception ex)
            {
                retval = String.Format("ERROR: (MakeGet) {0}", ex.Message);
            }
            return retval;
        }
        // Get the UserApiKey
        public string GetUserKey(Hashtable args)
        {
            NameValueCollection vals = new NameValueCollection();
            string retval;
            try
            {
                // Check for userid
                if (args.ContainsKey("api_user_name") == false)
                {
                    throw new Exception("No api_user_name");
                }
                else
                {
                    vals.Add("api_user_name", args["api_user_name"].ToString());
                }
                // Check for password
                if (args.ContainsKey("api_user_password") == false)
                {
                    throw new Exception("api_user_password");
                }
                else
                {
                    vals.Add("api_user_password", args["api_user_password"].ToString());
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
                        vals.Add("api_dev_key", _developer_api_key);
                    }
                }
                else
                {
                    vals.Add("api_dev_key", args["api_dev_key"].ToString());
                }
                retval = MakePost(_login_url, vals);
                // Go on and assign the local variable if we get this far
                if (retval.Length > 0) { _user_key = retval; }
            }
            catch (Exception ex)
            {
                retval = String.Format("ERROR: (GetUserKey) {0}", ex.Message);
            }
            return retval;
        }
        // Handles the POST requests
        protected string MakePost(string url, NameValueCollection args)
        {
            WebClient wc = new WebClient();
            string retval = "";
            try
            {
                byte[] res = wc.UploadValues(url, "POST", args);
                retval = Encoding.UTF8.GetString(res);
            }
            catch (WebException we)
            {
                retval = String.Format("WEB EXCEPTION: (MakePost) {0}", we.Message);
            }
            catch (Exception ex)
            {
                retval = String.Format("EXCEPTION: (MakePost) {0}", ex.Message);
            }
            return retval;
        }
        // Handles GET requests
        protected string MakeGet(string url)
        {
            WebClient wc = new WebClient();
            string retval = "";
            try
            {
                retval = wc.DownloadString(url);
            }
            catch (WebException we)
            {
                retval = String.Format("WEB EXCEPTION: (MakeGet) {0}", we.Message);
            }
            catch (Exception ex)
            {
                retval = String.Format("EXCEPTION: (MakeGet) {0}", ex.Message);
            }
            return retval;
        }
        // CONSTRUCTOR
        // No arguments
        public Pastebin() { }
        // With one argument: DeveloperApiKey
        public Pastebin(string dak) { _developer_api_key = dak; }
        // With two arguments: DeveloperApiKey, UserApiKey
        public Pastebin(string dak, string uak) { _developer_api_key = dak; _user_key = uak; }
    }
    // Pastebin class functions often take Hashtabe arguments.
    // PastebinAtgs will accept arguments and then output them as a Hashtable.
    class PastebinArgs
    {
        public Hashtable ToHashtable()
        {
            Hashtable ht = new Hashtable();
            return ht;
        }
        // CONSTRUCTOR
        public PastebinArgs() { }
    }
}