
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace pocPagSeguro.Controllers
{
    public class TesteController : Controller
    {
        public FileResult Azure()
        {
            var mr = new MemoryStream();
            var tw = new StreamWriter(mr);
            tw.WriteLine("2jpvbqmp3h5ltmuju1v3jv3hku");
            tw.Flush();
            return File(mr.ToArray(), "text/plain", "godaddy.html");
        }

        public FileResult Apple()
        {
            var mr = new MemoryStream();
            var tw = new StreamWriter(mr);
            tw.WriteLine("MIIQ5AYJKoZIhvcNAQcCoIIQ1TCCENECAQExCzAJBgUrDgMCGgUAMHoGCSqGSIb3DQEHAaBtBGt7");
            tw.WriteLine("InRlYW1JZCI6IjNNTjJNMjhKMkEiLCJkb21haW4iOiJwYWdhbWVudG8ua2VzaWFrbGF2YS5jb20i");
            tw.WriteLine("LCJkYXRlQ3JlYXRlZCI6IjIwMTktMDEtMzEsMjE6MjM6NDMiLCJ2ZXJzaW9uIjoxfaCCDbEwggPz");
            tw.WriteLine("MIIC26ADAgECAgEXMA0GCSqGSIb3DQEBBQUAMGIxCzAJBgNVBAYTAlVTMRMwEQYDVQQKEwpBcHBs");
            tw.WriteLine("ZSBJbmMuMSYwJAYDVQQLEx1BcHBsZSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0eTEWMBQGA1UEAxMN");
            tw.WriteLine("QXBwbGUgUm9vdCBDQTAeFw0wNzA0MTIxNzQzMjhaFw0yMjA0MTIxNzQzMjhaMHkxCzAJBgNVBAYT");
            tw.WriteLine("AlVTMRMwEQYDVQQKEwpBcHBsZSBJbmMuMSYwJAYDVQQLEx1BcHBsZSBDZXJ0aWZpY2F0aW9uIEF1");
            tw.WriteLine("dGhvcml0eTEtMCsGA1UEAxMkQXBwbGUgaVBob25lIENlcnRpZmljYXRpb24gQXV0aG9yaXR5MIIB");
            tw.WriteLine("IjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAox6-8EfAtJ4QW0akuCG4T4YhcChFYFwcw8gK");
            tw.WriteLine("ZGOI-_xp7vhU_OlbtwZOBC_DazOvREzqS4AJtIf2W7T9ZN2zcuATs_0X2bznqO3CjGHCKvnszqVe");
            tw.WriteLine("1mnrZAuNCI-4oFBGCdwZ5OWwlG2795mYxOibQU7U8WXjG1J63OgD2W4d2hBVhqQpWEkM6kfXFTQz");
            tw.WriteLine("9sCgREpwviy1KjA3jC4V69HkbJc4VVaxNStY6kSjJoXuyGZK5M-J8D1jrSnerbpas9ylo5qnCU6A");
            tw.WriteLine("FjVlpIUNY3s-Y4rafUpG7KM5GDS5xihlGLwTYJx_V6wUyYntobaHaFK2hE64yIPs-Z4Zq7PBC4bH");
            tw.WriteLine("nwIDAQABo4GcMIGZMA4GA1UdDwEB_wQEAwIBhjAPBgNVHRMBAf8EBTADAQH_MB0GA1UdDgQWBBTn");
            tw.WriteLine("NCouIt45YGu0lM53g2EvMaB8NTAfBgNVHSMEGDAWgBQr0GlHlHYJ_vRrjS5ApvdHTX8IXjA2BgNV");
            tw.WriteLine("HR8ELzAtMCugKaAnhiVodHRwOi8vd3d3LmFwcGxlLmNvbS9hcHBsZWNhL3Jvb3QuY3JsMA0GCSqG");
            tw.WriteLine("SIb3DQEBBQUAA4IBAQAd0dV73XRO1xf8gi0MmZteQnLyadzVa14NDGtLPnsUJd6zlOig-g-AifIX");
            tw.WriteLine("PQACopGRvnRX3K-an6EKfTC-ACrMIVnr_UmsbnUZ6Jp6A9GG9uf2sA5LSfqjt0G619HjVqF9g6uX");
            tw.WriteLine("rvhRSibBhUITJo0DVGYQXmCEBRIxK2tUwKDIQbxUHudUrRMA0krHu8GKr4EIjvBGCr8npr7czzk6");
            tw.WriteLine("gHAZIzKja2Zdnk2oR0mye0W1UTOndGcJTrZsb0j3LLkzBURrRb50S2-yhpG0PiUoJZ6zwlGG_E_l");
            tw.WriteLine("rzuqu0QsAUnidLM0-kTvFMIR8i0ZGlGJ0whKQWxYVt6bOuEFV-Viz9IPMIID-DCCAuCgAwIBAgII");
            tw.WriteLine("PXIg48-M8iUwDQYJKoZIhvcNAQEFBQAweTELMAkGA1UEBhMCVVMxEzARBgNVBAoTCkFwcGxlIElu");
            tw.WriteLine("Yy4xJjAkBgNVBAsTHUFwcGxlIENlcnRpZmljYXRpb24gQXV0aG9yaXR5MS0wKwYDVQQDEyRBcHBs");
            tw.WriteLine("ZSBpUGhvbmUgQ2VydGlmaWNhdGlvbiBBdXRob3JpdHkwHhcNMTQwNzExMDEzNTI1WhcNMjIwNDEy");
            tw.WriteLine("MTc0MzI4WjBZMQswCQYDVQQGEwJVUzETMBEGA1UECgwKQXBwbGUgSW5jLjE1MDMGA1UEAwwsQXBw");
            tw.WriteLine("bGUgaVBob25lIE9TIFByb3Zpc2lvbmluZyBQcm9maWxlIFNpZ25pbmcwggEiMA0GCSqGSIb3DQEB");
            tw.WriteLine("AQUAA4IBDwAwggEKAoIBAQDn2ZrDF6PJ6QfVx5mktHUhTBEDaB8wLAecd4gxSMhEBI2BzXrG-NP2");
            tw.WriteLine("RxxtTu665hSFccTvebNLddpohaZzVaLGh1F71xyBtQFq44yR7noq_M-VXvlxoCh--avU4c4OT5Xz");
            tw.WriteLine("yu23lQoy_yWZNvaYnSSLZFe29f2-RSH5rkR2t-qwO2mfbX9-1xGbsupDouX9JkfOzMQH4ud1xtv8");
            tw.WriteLine("fha1pJPGfK89vd3AL4B4djpOfNhkTyolUYdBdg5u4JOkIao-Xcpfp4sLQKUvs7NqSsfGU7UfXCyK");
            tw.WriteLine("iO7kkC-f3VI-FkHGOB5oJI8xLdtpcc-g80IaKBFKdJym1nhJWA3EvBxb8T17AgMBAAGjgaMwgaAw");
            tw.WriteLine("HQYDVR0OBBYEFKReazv8ekdykXAJwSS9LzvJe6C-MAwGA1UdEwEB_wQCMAAwHwYDVR0jBBgwFoAU");
            tw.WriteLine("5zQqLiLeOWBrtJTOd4NhLzGgfDUwMAYDVR0fBCkwJzAloCOgIYYfaHR0cDovL2NybC5hcHBsZS5j");
            tw.WriteLine("b20vaXBob25lLmNybDALBgNVHQ8EBAMCB4AwEQYLKoZIhvdjZAYCAgEEAgUAMA0GCSqGSIb3DQEB");
            tw.WriteLine("BQUAA4IBAQCKtlZOQdKx8yFDnQvZx_-0mFiZ7UGnMPHv29qAbSG2s1zcvofxOSG8xKHaJtLtpvHt");
            tw.WriteLine("wBGVGaxHuCoOaZjU5ubOa-oiwSunAW5BTCwd4yOMhiejjBeczBvu2GQzD0QOiztIYhNiVNNxTZIt");
            tw.WriteLine("gTr_psuOXENxbIgzIjwgPx14uf8aKiHoc2nPm6Gh4T3pDBe8qXPX6VK6wrYfoSKFPrhcGrKae5_M");
            tw.WriteLine("y1A6_pbH_EhH9CSirT5M-0rbZ5wDcRUnP4NS-7L0GRapPqnsFOxewgqn803RMKrUrbgyoVAvTVXI");
            tw.WriteLine("QiesHM5yZPAs4AnkTLkLIDU3nNULkcQxHdAr4lyCvX3Q_giZMIIFujCCBKKgAwIBAgIBATANBgkq");
            tw.WriteLine("hkiG9w0BAQUFADCBhjELMAkGA1UEBhMCVVMxHTAbBgNVBAoTFEFwcGxlIENvbXB1dGVyLCBJbmMu");
            tw.WriteLine("MS0wKwYDVQQLEyRBcHBsZSBDb21wdXRlciBDZXJ0aWZpY2F0ZSBBdXRob3JpdHkxKTAnBgNVBAMT");
            tw.WriteLine("IEFwcGxlIFJvb3QgQ2VydGlmaWNhdGUgQXV0aG9yaXR5MB4XDTA1MDIxMDAwMTgxNFoXDTI1MDIx");
            tw.WriteLine("MDAwMTgxNFowgYYxCzAJBgNVBAYTAlVTMR0wGwYDVQQKExRBcHBsZSBDb21wdXRlciwgSW5jLjEt");
            tw.WriteLine("MCsGA1UECxMkQXBwbGUgQ29tcHV0ZXIgQ2VydGlmaWNhdGUgQXV0aG9yaXR5MSkwJwYDVQQDEyBB");
            tw.WriteLine("cHBsZSBSb290IENlcnRpZmljYXRlIEF1dGhvcml0eTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCC");
            tw.WriteLine("AQoCggEBAOSRqQkfkdseR1DrBe1eeYQt6zaiV0xV7IsZid75S2z1B6siMALoGD74UAnTf0GomPnR");
            tw.WriteLine("ymacJGsR0KO75Bsqwx-VnnoMpEeLW9QWNzPLxA9NzhRp0ckZcvVdDtV_X5vyJQO6VY9NXQ3xZDUj");
            tw.WriteLine("FUsVWR2zlPf2nJ7PULrBWFBnjwi0IPfLrCwgb3C2PwEwjLdDzw-dPfMrSSgayP7OtbkO2V4c1ss9");
            tw.WriteLine("tTqt9A8OAJILsSEWLnTVPA3bYharo3GSR1NVwa8vQbP4--NwzeajTEV-H0xrUJZBicR0YgsQg0GH");
            tw.WriteLine("M4qBsTBY7FoEMoxos48d3mVz_2deZbxJ2HafMxRloXeUyS0CAwEAAaOCAi8wggIrMA4GA1UdDwEB");
            tw.WriteLine("_wQEAwIBBjAPBgNVHRMBAf8EBTADAQH_MB0GA1UdDgQWBBQr0GlHlHYJ_vRrjS5ApvdHTX8IXjAf");
            tw.WriteLine("BgNVHSMEGDAWgBQr0GlHlHYJ_vRrjS5ApvdHTX8IXjCCASkGA1UdIASCASAwggEcMIIBGAYJKoZI");
            tw.WriteLine("hvdjZAUBMIIBCTBBBggrBgEFBQcCARY1aHR0cHM6Ly93d3cuYXBwbGUuY29tL2NlcnRpZmljYXRl");
            tw.WriteLine("YXV0aG9yaXR5L3Rlcm1zLmh0bWwwgcMGCCsGAQUFBwICMIG2GoGzUmVsaWFuY2Ugb24gdGhpcyBj");
            tw.WriteLine("ZXJ0aWZpY2F0ZSBieSBhbnkgcGFydHkgYXNzdW1lcyBhY2NlcHRhbmNlIG9mIHRoZSB0aGVuIGFw");
            tw.WriteLine("cGxpY2FibGUgc3RhbmRhcmQgdGVybXMgYW5kIGNvbmRpdGlvbnMgb2YgdXNlLCBjZXJ0aWZpY2F0");
            tw.WriteLine("ZSBwb2xpY3kgYW5kIGNlcnRpZmljYXRpb24gcHJhY3RpY2Ugc3RhdGVtZW50cy4wRAYDVR0fBD0w");
            tw.WriteLine("OzA5oDegNYYzaHR0cHM6Ly93d3cuYXBwbGUuY29tL2NlcnRpZmljYXRlYXV0aG9yaXR5L3Jvb3Qu");
            tw.WriteLine("Y3JsMFUGCCsGAQUFBwEBBEkwRzBFBggrBgEFBQcwAoY5aHR0cHM6Ly93d3cuYXBwbGUuY29tL2Nl");
            tw.WriteLine("cnRpZmljYXRlYXV0aG9yaXR5L2Nhc2lnbmVycy5odG1sMA0GCSqGSIb3DQEBBQUAA4IBAQCd2i0o");
            tw.WriteLine("WC99dgS5BNM-zrdmY06PL9T-S61yvaM5xlJNBZhS9YlRASR5vhoy9-VEi0tEBzmC1lrKtCBe2a4V");
            tw.WriteLine("XR2MHTK_ODFiSF3H4ZCx-CRA-F9Ym1FdV53B5f88zHIhbsTp6aF31ywXJsM_65roCwO66bNKcusz");
            tw.WriteLine("CVut5mIxauivL9WvHld2j383LS4CXN1jyfJxuCZA3xWNdUQ_eb3mHZnhQyw-rW--uaT-DjUZUWOx");
            tw.WriteLine("w961kj5ReAFziqQjyqSI8R5cH0EWLX6VCqrpiUGYGxrdyyC_R14MJsVVNU3GMIuZZxTHCR-6R8fa");
            tw.WriteLine("AQmHJEKVvRNgGQrv6n8Obs3BREM6StXjMYICjDCCAogCAQEwgYUweTELMAkGA1UEBhMCVVMxEzAR");
            tw.WriteLine("BgNVBAoTCkFwcGxlIEluYy4xJjAkBgNVBAsTHUFwcGxlIENlcnRpZmljYXRpb24gQXV0aG9yaXR5");
            tw.WriteLine("MS0wKwYDVQQDEyRBcHBsZSBpUGhvbmUgQ2VydGlmaWNhdGlvbiBBdXRob3JpdHkCCD1yIOPPjPIl");
            tw.WriteLine("MAkGBSsOAwIaBQCggdwwGAYJKoZIhvcNAQkDMQsGCSqGSIb3DQEHATAcBgkqhkiG9w0BCQUxDxcN");
            tw.WriteLine("MTkwMTMxMjEyMzQzWjAjBgkqhkiG9w0BCQQxFgQUh-SIjkhlN2KHQNP5yoDUi7UztpgwKQYJKoZI");
            tw.WriteLine("hvcNAQk0MRwwGjAJBgUrDgMCGgUAoQ0GCSqGSIb3DQEBAQUAMFIGCSqGSIb3DQEJDzFFMEMwCgYI");
            tw.WriteLine("KoZIhvcNAwcwDgYIKoZIhvcNAwICAgCAMA0GCCqGSIb3DQMCAgFAMAcGBSsOAwIHMA0GCCqGSIb3");
            tw.WriteLine("DQMCAgEoMA0GCSqGSIb3DQEBAQUABIIBAIysujp69rAtrtr4RtY-X3SmMceuPQHqWwkVj1lJKmvR");
            tw.WriteLine("NCxtce8oyOIw1NA5Qi82TRQW0qFbOqeiur9Y5dSRPGMnZlwvCrxCL69io-u7GRv07rXgImZ611Ht");
            tw.WriteLine("tJhdgkAD1FMdreZDQB1NtZ0cUwrESVU_Z98oh7nmoAUC7Xt-evTFbT64AYZf99LJnvsFpwVYFCq4");
            tw.WriteLine("AHcxS5W2G4Q9faLVuvpqHC9Y1k7tVBhrNvVZ4FKV7DKxbYrroUW3BNIxqGQV70szAlyA3414EqfM");
            tw.WriteLine("IKI9tLb7zjSN-BCL0FhX2M9mLl_47AdM4dmhV0-kYx5OBYdSFj_kp7nsZ4mE-gPS3JiNC34");
            tw.Flush();

            return File(mr.ToArray(), "text/plain", "apple-developer-merchantid-domain-association.txt");

        }
    }
}
