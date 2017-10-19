﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace ExtractLib
{
    /// <summary>
    /// 使用正则表达式抽取文本内容
    /// </summary>
    public class RegexMethod
    {
        /// <summary>
        /// 抽取单条
        /// </summary>
        /// <param name="Regstr">正则表达式字符串</param>
        /// <param name="Txt">待匹配的文本</param>
        /// <returns></returns>
        public static String GetSingleResult(String Regstr, String Txt)
        {
            String retStr = String.Empty;
            if (String.IsNullOrEmpty(Txt))
            {
                return String.Empty;
            }
            if (!String.IsNullOrEmpty(Regstr))
            {
                Regex reg = new Regex(Regstr);
                if (reg.IsMatch(Txt))
                {
                    retStr = reg.Match(Txt).Value;
                }
            }
            return retStr;
        }
        /// <summary>
        /// 抽取单条 指定层数
        /// </summary>
        /// <param name="Regstr">正则表达式字符串</param>
        /// <param name="Txt">待匹配的文本</param>
        /// <param name="Layer">抽取层数</param>
        /// <returns></returns>
        public static String GetSingleResult(String Regstr, String Txt, int Layer)
        {
            String retStr = String.Empty;
            if(String.IsNullOrEmpty(Txt))
            {
                return String.Empty;
            }
            if (!String.IsNullOrEmpty(Regstr))
            {
                Regex reg = new Regex(Regstr);
                if (reg.IsMatch(Txt))
                {
                    retStr = reg.Match(Txt).Groups[Layer].Value;
                    if(!String.IsNullOrEmpty(retStr))
                    {
                        retStr = retStr.Trim();
                    }
                }
            }
            return retStr;
        }
        /// <summary>
        /// 抽取多条
        /// </summary>
        /// <param name="Regstr">正则表达式字符串</param>
        /// <param name="Txt">待匹配的文本</param>
        /// <returns></returns>
        public static List<String> GetMutResult(String Regstr, String Txt,RegexOptions regop = RegexOptions.None)
        {
            if(String.IsNullOrEmpty(Txt))
            {
                return null;
            }
            List<String> RetList = new List<string>();
            if (!String.IsNullOrEmpty(Regstr))
            {
                Regex reg = new Regex(Regstr,regop);
                if (reg.IsMatch(Txt))
                {
                    MatchCollection mc = reg.Matches(Txt);
                    foreach (Match m in mc)
                    {
                        RetList.Add(m.Value);
                    }
                }
            }
            return RetList;
        }
        /// <summary>
        /// 抽取多条 指定层数
        /// </summary>
        /// <param name="Regstr">正则表达式字符串</param>
        /// <param name="Txt">待匹配的文本</param>
        /// <param name="Layer">抽取层数</param>
        /// <returns></returns>
        public static List<String> GetMutResult(String Regstr, String Txt, int Layer)
        {
            if(String.IsNullOrEmpty(Txt))
            {
                return null;
            }
            List<String> RetList = new List<string>();
            if (!String.IsNullOrEmpty(Regstr))
            {
                Regex reg = new Regex(Regstr);
                if (reg.IsMatch(Txt))
                {
                    MatchCollection mc = reg.Matches(Txt);
                    foreach (Match m in mc)
                    {
                        RetList.Add(m.Groups[Layer].Value);
                    }
                }
            }
            return RetList;
        }
        /// <summary>
        /// 使用正则表达式替换文本
        /// </summary>
        /// <param name="Regstr">正则表达式字符串</param>
        /// <param name="Txt">待替换的文本</param>
        /// <param name="Repstr">代替的文本</param>
        /// <returns>返回替换后的文本</returns>
        public static String RegReplace(String Regstr, String Txt, String Repstr)
        {
            if (String.IsNullOrEmpty(Txt))
            {
                return String.Empty;
            }
            Regex reg = new Regex(Regstr);
            return reg.Replace(Txt, Repstr);
        }
        /// <summary>
        /// 检验正则表达式是否有匹配
        /// </summary>
        /// <param name="Regstr"></param>
        /// <param name="Txt"></param>
        /// <returns></returns>
        public static bool CheckRegex(String Regstr, String Txt)
        {
            if(String.IsNullOrEmpty(Txt))
            {
                return false;
            }
            Regex reg = new Regex(Regstr);
            return reg.IsMatch(Txt);
        }
        /// <summary>
        /// 使用正则表达式分割文本 返回String[]
        /// </summary>
        /// <param name="Regstr">字符串类型的正则表达式</param>
        /// <param name="Txt">待分割的文本</param>
        /// <returns></returns>
        public static String[] RegSplit(String Regstr,String Txt)
        {
            if (String.IsNullOrEmpty(Txt))
            {
                return null;
            }
            Regex reg = new Regex(Regstr);
            return reg.Split(Txt);
        }

        public static String GetNum<T>(T p)
        {
            String str = RegexMethod.GetSingleResult("[0-9]+",Convert.ToString(p));
            if(String.IsNullOrEmpty(str))
            {
                return "0";
            }
            return str;
        }
    }
}