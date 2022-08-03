using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Json;

namespace SecIotAgent.WEB
{

    public struct ICTK_JSON_SUBSGTRUCT_INITCERTINFO
    {
        public string caCrtId;
        public string dvcCrtId;
        public string dvcCrt;
    }

    public struct ICTK_JSON_SUBSTRUCT_ECC
    {
        public string signAlgorithm;
        public string signature;
    }

    public struct ICTK_JSON_SUBSTRUCT_PQC
    {
        public string signAlgorithm;
        public string signature;
    }

    public struct ICTK_JSON_SUBSTRUCT_SIGNATURE
    {
        public ICTK_JSON_SUBSTRUCT_ECC ecc;
        public ICTK_JSON_SUBSTRUCT_PQC pqc;
        // public byte[] Signature { get; set; }
    }

    public struct ICTK_JSON_SUBSTRUCT_HEADER
    {
        public string trId;
    }

    public struct ICTK_JSON_SUBSTRUCT_BODY
    {
        public string authType;
        public string uId;
        public string sessionId;
        public string format;
        public string caCrtId;
        public int expired;
        public ICTK_JSON_SUBSTRUCT_SIGNATURE signature;
        public ICTK_JSON_SUBSGTRUCT_INITCERTINFO initCertInfo;
    }

    public struct ICTK_JSON_STRUCT
    {
        public ICTK_JSON_SUBSTRUCT_HEADER Header;
        public ICTK_JSON_SUBSTRUCT_BODY Body;
    };

    internal class CSHAP_ICTK_JSON_Class
    {
        public string Make_Json(int MakeType)
        {
            
            return string.Empty;
        }

        public string MakeJsonSample()
        {
            string makejson = string.Empty;
            JsonObjectCollection header = new JsonObjectCollection();
            JsonObjectCollection body = new JsonObjectCollection();

            header.Name = "header";
            body.Name = "body";

            header.Add(new JsonStringValue("trId", "500301"));
            body.Add(new JsonStringValue("uId", "TEST_EMUL_0001"));

            makejson = "{" + header.ToString() + "," + body.ToString() + "}";

            return makejson;
        }

        ///
        public string make_challenge_json(string trId, string uId)
        {
            string retJson = string.Empty ;

            JsonObjectCollection header = new JsonObjectCollection();
            JsonObjectCollection body = new JsonObjectCollection();

            header.Name = "header";
            body.Name = "body";

            header.Add(new JsonStringValue("trId", trId));
            body.Add(new JsonStringValue("uId", uId));

            retJson = "{" + header.ToString() + "," + body.ToString() + "}";

            return retJson;
        }

        
        public string make_auth_json(ICTK_JSON_STRUCT jsonStruct)
        {
            string retjson = string.Empty ;
            JsonObjectCollection objectCollection = new JsonObjectCollection();
            JsonObjectCollection header = new JsonObjectCollection();
            JsonObjectCollection body = new JsonObjectCollection();
            JsonObjectCollection body_signature = new JsonObjectCollection();
            JsonObjectCollection body_signature_ecc = new JsonObjectCollection();
            JsonObjectCollection body_signature_pqc = new JsonObjectCollection();
            JsonObjectCollection body_initCerrtInfo = new JsonObjectCollection();
            
            header.Name = "header";
            header.Add(new JsonStringValue("trId", jsonStruct.Header.trId));

            objectCollection.Add(header);

            body.Name = "body";
            body.Add(new JsonStringValue("authType", jsonStruct.Body.authType));
            body.Add(new JsonStringValue("uId", jsonStruct.Body.uId));
            body.Add(new JsonStringValue("sessionId", jsonStruct.Body.sessionId));

            body_signature.Name = "signature";
            body_signature_ecc.Name = "ecc";
            body_signature_ecc.Add(new JsonStringValue("signAlgorithm", jsonStruct.Body.signature.ecc.signAlgorithm));
            body_signature_ecc.Add(new JsonStringValue("signature", jsonStruct.Body.signature.ecc.signature));
            body_signature.Add(body_signature_ecc);

            body_signature_pqc.Name = "pqc";
            body_signature_pqc.Add(new JsonStringValue("signAlgorithm", jsonStruct.Body.signature.pqc.signAlgorithm));
            body_signature_pqc.Add(new JsonStringValue("signature", jsonStruct.Body.signature.pqc.signature));
            body_signature.Add(body_signature_pqc);
            body.Add(body_signature);

            body_initCerrtInfo.Name = "initCerrtInfo";
            body_initCerrtInfo.Add(new JsonStringValue("caCrtId", jsonStruct.Body.initCertInfo.caCrtId));
            body_initCerrtInfo.Add(new JsonStringValue("dvcCrtId", jsonStruct.Body.initCertInfo.dvcCrtId));
            body_initCerrtInfo.Add(new JsonStringValue("dvcCrt", jsonStruct.Body.initCertInfo.dvcCrt));
            body.Add(body_initCerrtInfo);

            objectCollection.Add(body);
            retjson = objectCollection.ToString();

            return retjson;
        }
    }
}
