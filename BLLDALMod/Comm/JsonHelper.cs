using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Collections.Specialized;
using System.Reflection;

namespace BLLDALMod.Comm
{
    /// 类功能描述: json序列化反序列化
    /// </summary>
    public class JsonHelper
    {
        public static string Serialize<T>(T data)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(data.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, data);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// 通过URL获取泛型对象
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="url">Url字符串</param>
        /// <returns>返回泛型对象</returns>
        public static T GetTypeByUrl<T>(HttpContext context) where T : new()
        {
            //string querystring = context.Request.Params.ToString();
            //NameValueCollection col = GetQueryString(querystring);
            NameValueCollection col = context.Request.Params;

            T obj = new T();
            FieldInfo[] fieldlist = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo field in fieldlist)
            {
                if (!string.IsNullOrEmpty(col[field.Name]))
                {
                    if (field.FieldType.Name.IndexOf("Nullable`1") != -1)
                    {
                        if (field.FieldType.ToString().IndexOf("System.DateTime") != -1)
                        {
                            field.SetValue(obj, DateTime.Parse(col[field.Name].ToString()));
                        }
                        else if (field.FieldType.ToString().IndexOf("System.Double") != -1)
                        {
                            field.SetValue(obj, Double.Parse(col[field.Name].ToString()));
                        }
                        else if (field.FieldType.ToString().IndexOf("System.Decimal") != -1)
                        {
                            field.SetValue(obj, Decimal.Parse(col[field.Name].ToString()));
                        }
                        else if (field.FieldType.ToString().IndexOf("System.Int16") != -1)
                        {
                            field.SetValue(obj, Int16.Parse(col[field.Name].ToString()));
                        }
                        else if (field.FieldType.ToString().IndexOf("System.Int32") != -1)
                        {
                            field.SetValue(obj, Int32.Parse(col[field.Name].ToString()));
                        }
                        else if (field.FieldType.ToString().IndexOf("System.Int64") != -1)
                        {
                            field.SetValue(obj, Int64.Parse(col[field.Name].ToString()));
                        }
                        else if (field.FieldType.ToString().IndexOf("System.Boolean") != -1)
                        {
                            field.SetValue(obj, Boolean.Parse(col[field.Name].ToString()));
                        }
                        else if (field.FieldType.ToString().IndexOf("System.Guid") != -1)
                        {
                            field.SetValue(obj, new Guid(col[field.Name].ToString()));
                        }
                        else
                        {
                            field.SetValue(obj, col[field.Name].ToString());
                        }
                    }
                    else
                    {
                        switch (field.FieldType.Name)
                        {
                            case "DateTime":
                                field.SetValue(obj, DateTime.Parse(col[field.Name].ToString()));
                                break;
                            case "Double":
                                field.SetValue(obj, Double.Parse(col[field.Name].ToString()));
                                break;
                            case "Decimal":
                                field.SetValue(obj, Decimal.Parse(col[field.Name].ToString()));
                                break;
                            case "Int16":
                                field.SetValue(obj, Int16.Parse(col[field.Name].ToString()));
                                break;
                            case "Int32":
                                field.SetValue(obj, Int32.Parse(col[field.Name].ToString()));
                                break;
                            case "Int64":
                                field.SetValue(obj, Int64.Parse(col[field.Name].ToString()));
                                break;
                            case "Boolean":
                                field.SetValue(obj, Boolean.Parse(col[field.Name].ToString()));
                                break;
                            case "Guid":
                                field.SetValue(obj, new Guid(col[field.Name].ToString()));
                                break;
                            default:
                                field.SetValue(obj, col[field.Name].ToString());
                                break;
                        }
                    }
                }
            }

            PropertyInfo[] propertylist = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in propertylist)
            {
                if (!string.IsNullOrEmpty(col[property.Name]))
                {
                    if (property.PropertyType.Name.IndexOf("Nullable`1") != -1)
                    {
                        if (property.PropertyType.ToString().IndexOf("System.DateTime") != -1)
                        {
                            property.SetValue(obj, DateTime.Parse(col[property.Name].ToString()), null);
                        }
                        else if (property.PropertyType.ToString().IndexOf("System.Double") != -1)
                        {
                            property.SetValue(obj, Double.Parse(col[property.Name].ToString()), null);
                        }
                        else if (property.PropertyType.ToString().IndexOf("System.Decimal") != -1)
                        {
                            property.SetValue(obj, Decimal.Parse(col[property.Name].ToString()), null);
                        }
                        else if (property.PropertyType.ToString().IndexOf("System.Int16") != -1)
                        {
                            property.SetValue(obj, Int16.Parse(col[property.Name].ToString()), null);
                        }
                        else if (property.PropertyType.ToString().IndexOf("System.Int32") != -1)
                        {
                            property.SetValue(obj, Int32.Parse(col[property.Name].ToString()), null);
                        }
                        else if (property.PropertyType.ToString().IndexOf("System.Int64") != -1)
                        {
                            property.SetValue(obj, Int64.Parse(col[property.Name].ToString()), null);
                        }
                        else if (property.PropertyType.ToString().IndexOf("System.Boolean") != -1)
                        {
                            property.SetValue(obj, Boolean.Parse(col[property.Name].ToString()), null);
                        }
                        else if (property.PropertyType.ToString().IndexOf("System.Guid") != -1)
                        {
                            property.SetValue(obj, new Guid(col[property.Name].ToString()), null);
                        }
                        else
                        {
                            property.SetValue(obj, col[property.Name].ToString(), null);
                        }
                    }
                    else
                    {
                        switch (property.PropertyType.Name)
                        {
                            case "DateTime":
                                property.SetValue(obj, DateTime.Parse(col[property.Name].ToString()), null);
                                break;
                            case "Double":
                                property.SetValue(obj, Double.Parse(col[property.Name].ToString()), null);
                                break;
                            case "Decimal":
                                property.SetValue(obj, Decimal.Parse(col[property.Name].ToString()), null);
                                break;
                            case "Int16":
                                property.SetValue(obj, Int16.Parse(col[property.Name].ToString()), null);
                                break;
                            case "Int32":
                                property.SetValue(obj, Int32.Parse(col[property.Name].ToString()), null);
                                break;
                            case "Int64":
                                property.SetValue(obj, Int64.Parse(col[property.Name].ToString()), null);
                                break;
                            case "Boolean":
                                property.SetValue(obj, Boolean.Parse(col[property.Name].ToString()), null);
                                break;
                            case "Guid":
                                property.SetValue(obj, new Guid(col[property.Name].ToString()), null);
                                break;
                            default:
                                property.SetValue(obj, col[property.Name].ToString(), null);
                                break;
                        }
                    }
                }
            }

            return obj;
        }
    }
}
