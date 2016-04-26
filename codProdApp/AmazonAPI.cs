using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace codProdApp
{
    public class AmazonAPI
    {
        private const string key = "key";
        private const string message = "message";
        private static readonly Encoding encoding = Encoding.UTF8; 
        // first, add this to the top of your code file: using System.Text.RegularExpressions;
        string UrlEncode(string url)
        {
    
            Dictionary<string, string> toBeEncoded = new Dictionary<string, string>() { { "%", "%25" }, { "!", "%21" }, { "#", "%23" }, { " ", "%20" },
            { "$", "%24" }, { "&", "%26" }, { "'", "%27" }, { "(", "%28" }, { ")", "%29" }, { "*", "%2A" }, { "+", "%2B" }, { ",", "%2C" }, 
            { "/", "%2F" }, { ":", "%3A" }, { ";", "%3B" }, { "=", "%3D" }, { "?", "%3F" }, { "@", "%40" }, { "[", "%5B" }, { "]", "%5D" } };
            Regex replaceRegex = new Regex(@"[%!# $&'()*+,/:;=?@\[\]]");
            MatchEvaluator matchEval = match => toBeEncoded[match.Value];
            string encoded = replaceRegex.Replace(url, matchEval);
            return encoded;
        }
        static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2"); /* hex format */
            return sbinary;
        }    

        public static string Base64Encode(string plainText) {
          var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
          return System.Convert.ToBase64String(plainTextBytes);
        }

        private string aws_query(List<Parametro> extraparams) {
    //$private_key = ACCESS_SECRET_KEY;
    string private_key = "UqHhyww1yikueZiesYPUno3VfsX6RDTCVzhLxjqw";

    string method = "GET";
    string host = "webservices.amazon.es";
    string uri = "/onca/xml";

    List<Parametro> _params = new List<Parametro>{
        //AssociateTag" => ASSOCIATE_TAG,
            new Parametro("AssociateTag" , "3dart0b-20"),
            new Parametro("Service" , "AWSECommerceService"),
        //"AWSAccessKeyId" => ACCESS_KEY_ID,
            new Parametro("AWSAccessKeyId" , "AKIAJ7KLPACQDGVVETIA"),
            new Parametro("Timestamp" , DateTime.Today.ToString("O")),
            new Parametro("SignatureMethod" , "HmacSHA256"),
            new Parametro("SignatureVersion" , "2"),
            new Parametro("Version" , "2013-08-01")
        };

    foreach (Parametro param in extraparams) {

        _params.Add(param);
    }
    _params = _params.OrderBy(x=>x.Nombre).ToList();
    

    // sort the parameters
    // create the canonicalized query
    List<string> canonicalized_query = new List<string>();
    foreach (Parametro param in _params) {
        //$param = str_replace("%7E", "~", rawurlencode($param));
        param.Nombre = this.UrlEncode(param.Nombre);
        param.Nombre =  param.Nombre.Replace("%7E", "~");
        //$value = str_replace("%7E", "~", rawurlencode($value));
        param.Valor=this.UrlEncode(param.Valor);
        param.Valor =  param.Valor.Replace("%7E", "~");
        //$canonicalized_query[] = $param . "=" . $value;
        canonicalized_query.Add(param.Nombre+"="+param.Valor);
    }
    //$canonicalized_query = implode("&", $canonicalized_query);
            string canonical = String.Join("&",canonicalized_query);

    // create the string to sign
    string string_to_sign =
        method + "\n" +
        host + "\n" +
        uri + "\n" +
        canonical;

    // calculate HMAC with SHA256 and base64-encoding
        var keyByte = encoding.GetBytes(private_key);
            string signature;
        using (var hmacsha256 = new HMACSHA256(keyByte))
        {
            hmacsha256.ComputeHash(encoding.GetBytes(string_to_sign));
            signature = Base64Encode(ByteToString(hmacsha256.Hash));
            //Console.WriteLine("Result: {0}", ByteToString(hmacsha256.Hash));
        }
    //string signature = base64_encode(
       // hash_hmac("sha256", $string_to_sign, $private_key, True));
            

    // encode the signature for the equest
            signature = UrlEncode(signature);
    signature = signature.Replace("%7E", "~");

    // Put the signature into the parameters
            _params.Add(new Parametro("Signature",signature));
    
    /*uksort($params, "strnatcasecmp");

    // TODO: the timestamp colons get urlencoded by http_build_query
    //       and then need to be urldecoded to keep AWS happy. Spaces
    //       get reencoded as %20, as the + encoding doesn't work with 
    //       AWS
    $query = urldecode(http_build_query($params));
    $query = str_replace(' ', '%20', $query);

    $string_to_send = "https://" . $host . $uri . "?" . $query;

    return $string_to_send;
}

function aws_itemlookup($itemId) {
    
    return $this->aws_query(array (
        "Operation" => "ItemLookup",
        "IdType" => "ASIN",
        "ResponseGroup" => "ItemAttributes",
        "ItemId" => $itemId
    ));
}

function aws_itemSearch($itemDesc) {
    
    return $this->aws_query(array (
        "Operation" => "ItemSearch",
        "SearchIndex" => "All",
        "ResponseGroup" => "ItemAttributes,Images",
        "Keywords" => $itemDesc
    ));*/
            return null;
}

    
    }
}
