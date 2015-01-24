#!/usr/bin/perl -w
use strict;
use warnings;

while(<DATA>) {
    $_ =~ s/(\n|\r)//g;
    print <<"EOL"
        public string $_
        {
            get { return GetVal("$_"); }
            set { ht["$_"] = value; }
        }
EOL
}

__DATA__
api_dev_key
api_option
api_paste_code
api_paste_expire_date
api_paste_format
api_paste_key
api_paste_name
api_paste_private
api_results_limit
api_user_key
api_user_name
api_user_password
paste_key