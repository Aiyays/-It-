using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Drawing;

namespace YCF_ServerTo1703
{
    public class Json
    {
        #region 传送信息统一格式

        /*
                /// <summary>
        /// 将一个对象生成josn字符串
        /// </summary>
        /// <param 任意对象类型="obj"></param>
        /// <returns>返回一个json字符串</returns>
        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            
            serializer.WriteObject(stream, obj);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;

            stream.Read(dataBytes, 0, (int)stream.Length);
            return UTF8Encoding.UTF8.GetString(dataBytes);
        }
             */



        /*
         /// <summary>
        /// 将一个josn串解析成对象
        /// </summary>
        /// <param json串="jsonString"></param>
        /// <param 对象类型="obj"></param>
        /// <returns></returns>
        public static object JsonToObject(string jsonString, object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream mStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(jsonString));
            return serializer.ReadObject(mStream);
        }
             */


        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string ObjectToJson(object o)
        {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }

        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }

        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T JsonToObject<T>(string json, T anonymousTypeObject)
        {
            T t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
            return t;
        }


        #endregion


        #region 对于图片的相互转换

        /// <summary>
        /// img转byte
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public byte[] GetByToImage(Image img)
        {
            byte[] bt = null;
            if (!img.Equals(null))
            {
                using (MemoryStream mostream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(mostream, System.Drawing.Imaging.ImageFormat.Bmp);//将图像以指定的格式存入缓存内存流
                    bt = new byte[mostream.Length];
                    mostream.Position = 0;//设置留的初始位置
                    mostream.Read(bt, 0, Convert.ToInt32(bt.Length));
                }
            }


            return bt;
        }

        /// <summary>
        /// byte转img
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Image GetImageToBytes(byte[] bytes)
        {
            Image photo = null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                ms.Write(bytes, 0, bytes.Length);
                photo = Image.FromStream(ms, true);
            }

            return photo;


        }


        public static Image GetImage(string ImageRoute)
        {
            return Image.FromFile(ImageRoute);
        }

        /// <summary>
        /// 存出到本地路径
        /// </summary>
        /// <param name="image"></param>
        /// <param name="name"></param>
        public static void SaveImage(Image image, string name)
        {
            DateTime a = DateTime.Now;
            string Dir = @"..\" + a.Year + a.Month + a.Day;
            if (!Directory.Exists(Dir)) Directory.CreateDirectory(Dir);
            
            image.Save(Dir+@"\"+name+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

        }

        //判断地址是否存在文件夹
        public static void asd(string txtFileSaveDir)
        {
            if (!Directory.Exists(txtFileSaveDir))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(txtFileSaveDir); //新建文件夹   
            }
        }


        #endregion



    }
}
