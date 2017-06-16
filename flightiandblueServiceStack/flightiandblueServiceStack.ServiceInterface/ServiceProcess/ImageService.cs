using flightiandblueServiceStack.ServiceModel;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using System.Security.Cryptography;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using BLLDALMod.Model;
using BLLDALMod.BLL;

namespace flightiandblueServiceStack.ServiceInterface.ServiceProcess
{
    public class ImageService : Service
    {
        const int ThumbnailSize = 100;
        //readonly string UploadsDir = "~/uploads".MapHostAbsolutePath();
        //public string UploadsDir = "E:\\www\\servicestack\\Imgur\\uploads\\";
        //public string UploadsDir = HttpContext.Current.Server.MapPath("/uploads/");
        public string UploadsDir = PublicConfig.uploadPath;
        //readonly string ThumbnailsDir = "~/uploads/thumbnails".MapHostAbsolutePath();
        readonly List<string> ImageSizes = new[] { "50", "100", "160", "350" }.ToList();
        //readonly List<string> ImageSizes = new[] { "320x480", "640x960", "640x1136", "768x1024", "1536x2048" }.ToList();
        string strErrorStackTrace = string.Empty;
        string strErrorMsg = string.Empty;


        //public object Get(Images request)
        //{
        //    return Directory.GetFiles(UploadsDir).ToList().ConvertAll(x => x.SplitOnLast(Path.DirectorySeparatorChar).Last());
        //}
        //public object Get(GetImages request)
        //{
        //    var dbFactory = new OrmLiteConnectionFactory("server=192.168.6.205; uid=test; pwd=abc123!@#$; database=test18;", SqlServerDialect.Provider);
        //    using (IDbConnection db = dbFactory.Open())
        //    {
        //        var a = db.Select<UserInfo>(x => x.RegisterId == request.RegisterId);
        //        request.IdentityCardImgNameHead = a[0].IdentityCardImgNameHead;
        //        request.IdentityCardImgNameTail = a[0].IdentityCardImgNameTail;
        //    }

        //    return request;
        //}
        //public object Post(Login request)
        //{
        //    string logname = request.Logname.Trim();
        //    string logpwd = FormsAuthentication.HashPasswordForStoringInConfigFile(request.Password.Trim(), "MD5");
        //    var dbFactory = new OrmLiteConnectionFactory("server=192.168.6.205; uid=test; pwd=abc123!@#$; database=test18;", SqlServerDialect.Provider);
        //    using (IDbConnection db = dbFactory.Open())
        //    {
        //        var a = db.Select<UserRegister>(x => x.LogName == logname && x.LogPwd == logpwd);
        //        if (a.Count != 1)
        //        {
        //            return HttpResult.Redirect("报错");
        //        }
        //    }

        //    return HttpResult.Redirect("/default1.html");
        //}

        public object Post(Upload request)
        {
            if (request.Type == 0)
            {
                try
                {
                    string fname = null;
                    string fname1 = null;
                    string fname2 = null;
                    int idcreatedir = 0;
                    idcreatedir = Convert.ToInt32(request.RegisterId) / 10000;
                    //UploadsDir = HttpContext.Current.Server.MapPath("/uploads/" + idcreatedir);
                    UploadsDir = PublicConfig.uploadPath + idcreatedir;
                    //UploadsDir = ("~/uploads/"+idcreatedir).MapHostAbsolutePath(); 
                    //UploadsDir = "F:\\www\\servicestack\\uploads\\" + idcreatedir;
                    //if (request.Card == null || (request.Card.Length != 15 && request.Card.Length != 18))
                    //{
                    //    return "认证失败，身份证号不正确";
                    //}

                    //var dbFactory = new OrmLiteConnectionFactory("server=192.168.6.205; uid=test; pwd=abc123!@#$; database=test18;", SqlServerDialect.Provider);
                    //var dbFactory = new OrmLiteConnectionFactory("server=192.168.1.12; uid=sa; pwd=Chengmou8888; database=DB_WanYuanShop;", SqlServerDialect.Provider);
                    //using (IDbConnection db = Db.Open())
                    //{
                    //var ur = Db.Select<web.ServiceModel.Types.UserRegister>(x => x.Id == request.RegisterId);
                    //string abc = Db.GetLastSql();
                    //DateTime d = ur[0].RegisterDate;
                    DateTime d2 = DateTime.Now.AddMinutes(-30);
                    // string mdd = FormsAuthentication.HashPasswordForStoringInConfigFile(ur[0].LogName, "MD5") + ur[0].LogPwd;
                    //if (ur[0].RegisterDate < DateTime.Now.AddMinutes(-30).Date)
                    //{
                    //    return "注册30分钟内才可以认证";
                    //}
                    //var a = Db.Select<UserInfo>(x => x.CardId == request.Card);
                    ////abc = Db.GetLastSql();
                    //if (a.Count > 5)
                    //{
                    //    return "认证失败,身份证号已被使用5次";
                    //}
                    //if (FormsAuthentication.HashPasswordForStoringInConfigFile(ur[0].LogName, "MD5") + ur[0].LogPwd != request.Md5)
                    //{
                    //    return "认证失败,身份验证错误";
                    //}

                    foreach (var uploadedFile in Request.Files.Where(uploadedFile => uploadedFile.ContentLength > 0))
                    {
                        if (uploadedFile.ContentLength > 1048576)  //大于1M 报错
                        {
                            return "认证失败，图片大于1M";
                        }
                        using (var ms = new MemoryStream())
                        {
                            uploadedFile.WriteTo(ms);
                            fname += WriteImage(ms) + ",";
                            // WriteImage(ms);
                        }
                    }
                    if (fname != null)
                    {
                        string[] str2 = fname.Split(',');
                        fname1 = str2[0];
                        fname2 = str2[1];
                    }

                    Goods objGoods = new Goods();
                    objGoods.Title = request.Title;
                    objGoods.MainImage = PublicConfig.ImgPath + idcreatedir + "/350/" + fname1;
                    objGoods.ContentValidity = request.Desc;
                    objGoods.PurchaseDate = request.PurchaseDate;
                    objGoods.AddTime = DateTime.Now;
                    objGoods.State = "0";
                    objGoods.Price = request.Price;
                    objGoods.UserId = request.RegisterId;
                    goodsBLL objGoodsBLL = new goodsBLL();
                    int a = objGoodsBLL.Add(objGoods);
                    if (a > 0)
                    {
                        return "上传成功";
                    }
                    else
                    {
                        return "上传失败";
                    }

                    //int i = Db.Update<UserInfo>(
                    //    new
                    //    {
                    //        CardId = request.Card,
                    //        IdentityCardImgNameHead = idcreatedir + "/350/" + fname1,
                    //        IdentityCardImgNameTail = idcreatedir + "/350/" + fname2,
                    //        AddressInfo = request.Address + "(手机端)",
                    //        ApplyCount = 1
                    //        //ApplyCount = db.Select<UserInfo>(x => x.RegisterId == request.RegisterId)[0].ApplyCount + 1
                    //    }, p => p.RegisterId == request.RegisterId && p.AuditState != 1 && p.ApplyCount == 0);
                    ////abc = Db.GetLastSql();
                    //if (i > 0)
                    //{
                    //    return "认证成功<input type='button' value='关闭' onclick='javascript: window.history.go(-4);'>";//成功
                    //}
                    //else
                    //{
                    //    return "认证失败,已申请过";//失败
                    //}

                }
                //return "认证成功<input type='button' value='关闭' onclick='javascript: window.history.go(-4);'>";//成功
                //return HttpResult.Redirect("/default1.html");
                //}
                //    catch (Exception e)
                //    {
                catch (Exception ex)
                {

                    if (ex.InnerException != null)
                    {
                        strErrorStackTrace += "" + ex.InnerException.StackTrace + "";
                        strErrorMsg = ex.InnerException.Message + strErrorMsg;

                    }
                    else
                    {
                        strErrorStackTrace += "" + ex.StackTrace + "";
                        strErrorMsg = ex.Message + strErrorMsg;
                    }
                    AddLog.AddWebLog(PublicEnum.LogType.GlobalError, "Global捕获页面异常", strErrorMsg, strErrorStackTrace);
                    return "认证失败";//失败
                }
                //        string strErr = string.Empty; //p_CmdParms 参数值                        
                //        CommModule.AddLog.AddMsgLog(CommModule.PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + SQLString + "\r\n参数    : " + strErr, e.StackTrace);
                //    }
                //    finally
                //    {
                //        CommModule.AddLog.AddSQLLog(db.GetLastSql();, dtStart.TimeOfDay.ToString(), DateTime.Now.TimeOfDay.ToString(), Convert.ToString(DateTime.Now - dtStart));
                //    }
            }
            else
            {
                try
                {
                    techs objtechs = new techs();
                    techsBLL objtechsBLL = new techsBLL();
                    objtechs.Title = request.Title;
                    objtechs.Url = request.Url;
                    objtechs.ContentValidity = request.Desc;
                    objtechs.UserId = request.RegisterId;
                    objtechs.AddTime = DateTime.Now;
                    objtechs.State = "0";
                    objtechs.type = "0";
                    if (objtechsBLL.Add(objtechs) > 0)
                    {
                        return "上传成功";
                    }
                    else {
                        return "上传失败";
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        strErrorStackTrace += "" + ex.InnerException.StackTrace + "";
                        strErrorMsg = ex.InnerException.Message + strErrorMsg;

                    }
                    else
                    {
                        strErrorStackTrace += "" + ex.StackTrace + "";
                        strErrorMsg = ex.Message + strErrorMsg;
                    }
                    AddLog.AddWebLog(PublicEnum.LogType.GlobalError, "Global捕获页面异常", strErrorMsg, strErrorStackTrace);
                }
                return "上传失败";
            }
        }
        private string WriteImage(Stream ms)
        {
            ms.Position = 0;
            var hash = Guid.NewGuid().ToString();
            //GetMd5Hash(ms.ReadFully());

            ms.Position = 0;
            var fileName = hash + ".png";
            using (var img = Image.FromStream(ms))
            {
                img.Save(AssertDir(UploadsDir.CombineWith("0/")).CombineWith(fileName));
                //var stream = Resize(img, ThumbnailSize, ThumbnailSize);
                //File.WriteAllBytes(ThumbnailsDir.CombineWith(fileName), stream.ReadFully());

                ImageSizes.ForEach(x => File.WriteAllBytes(
                    AssertDir(UploadsDir.CombineWith(x)).CombineWith(hash + ".png"),
                    Get(new Resize { Id = hash, Size = x }).ReadFully()));
            }
            return fileName;
        }

        [AddHeader(ContentType = "image/png")]
        public Stream Get(Resize request)
        {
            var imagePath = UploadsDir.CombineWith("0/" + request.Id + ".png");
            if (request.Id == null || !File.Exists(imagePath))
                throw HttpError.NotFound(request.Id + " was not found");

            using (var stream = File.OpenRead(imagePath))
            using (var img = Image.FromStream(stream))
            {
                //var parts = request.Size == null ? null : request.Size.Split('x');
                //int width = img.Width;
                //int height = img.Height;
                var parts = request.Size == null ? null : request.Size;
                int width = img.Width;
                int height = img.Height;
                if (parts != null && parts.Length > 0)
                {
                    int.TryParse(parts, out width);
                    int.TryParse(parts, out height);
                }
                //if (parts != null && parts.Length > 0)
                //    int.TryParse(parts[0], out width);

                //if (parts != null && parts.Length > 1)
                //    int.TryParse(parts[1], out height);

                return Resize(img, width, height);
            }
        }

        public static string GetMd5Hash(byte[] bytes)
        {
            var hash = MD5.Create().ComputeHash(bytes);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static Stream Resize(Image img, int newWidth, int newHeight)
        {
            if (newWidth != img.Width || newHeight != img.Height)
            {
                var ratioX = (double)newWidth / img.Width;
                var ratioY = (double)newHeight / img.Height;
                var ratio = Math.Max(ratioX, ratioY);
                var width = (int)(img.Width * ratio);
                var height = (int)(img.Height * ratio);

                var newImage = new Bitmap(width, height);                                       //按比列长宽缩放
                Graphics.FromImage(newImage).DrawImage(img, 0, 0, width, height);               //按比列长宽缩放
                //var newImage = new Bitmap(newWidth, newHeight);                               //按指定长宽缩放
                //Graphics.FromImage(newImage).DrawImage(img, 0, 0, newWidth, newHeight);       //按指定长宽缩放
                img = newImage;
                //if (img.Width != newWidth || img.Height != newHeight)
                //{
                //    var startX = (Math.Max(img.Width, newWidth) - Math.Min(img.Width, newWidth)) / 2;
                //    var startY = (Math.Max(img.Height, newHeight) - Math.Min(img.Height, newHeight)) / 2;
                //    img = Crop(img, newWidth, newHeight, startX, startY);                                        //裁剪
                //}
            }

            var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            return ms;
        }

        public static Image Crop(Image Image, int newWidth, int newHeight, int startX = 0, int startY = 0)
        {
            if (Image.Height < newHeight)
                newHeight = Image.Height;

            if (Image.Width < newWidth)
                newWidth = Image.Width;

            using (var bmp = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb))
            {
                bmp.SetResolution(72, 72);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.DrawImage(Image, new Rectangle(0, 0, newWidth, newHeight), startX, startY, newWidth, newHeight, GraphicsUnit.Pixel);

                    var ms = new MemoryStream();
                    bmp.Save(ms, ImageFormat.Png);
                    Image.Dispose();
                    var outimage = Image.FromStream(ms);
                    return outimage;
                }
            }
        }

        //public object Any(DeleteUpload request)
        //{
        //    var file = request.Id + ".png";
        //    var filesToDelete = new[] { UploadsDir.CombineWith(file) }.ToList();
        //    //var filesToDelete = new[] { UploadsDir.CombineWith(file), ThumbnailsDir.CombineWith(file) }.ToList();
        //    ImageSizes.Each(x => filesToDelete.Add(UploadsDir.CombineWith(x, file)));
        //    filesToDelete.Each(File.Delete);

        //    return HttpResult.Redirect("/");
        //}

        //public object Any(Reset request)
        //{
        //    Directory.GetFiles(AssertDir(UploadsDir)).ToList().ForEach(File.Delete);
        //    //Directory.GetFiles(AssertDir(ThumbnailsDir)).ToList().ForEach(File.Delete);
        //    ImageSizes.ForEach(x =>
        //        Directory.GetFiles(AssertDir(UploadsDir.CombineWith(x))).ToList().ForEach(File.Delete));
        //    File.ReadAllLines("~/preset-urls.txt".MapHostAbsolutePath()).ToList()
        //        .ForEach(url => WriteImage(new MemoryStream(url.Trim().GetBytesFromUrl())));

        //    return HttpResult.Redirect("/");
        //}

        private static string AssertDir(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            return dirPath;
        }
    }
}
