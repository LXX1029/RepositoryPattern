﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AspNetCore_NlogTest.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举变量值的 Description 属性
        /// </summary>
        /// <param name="obj">枚举变量</param>
        /// <returns>如果包含 Description 属性，则返回 Description 属性的值，否则返回枚举变量值的名称</returns>
        public static string GetDescription(this System.Enum obj)
        {
            return GetDescription(obj, false);
        }
        /// <summary>
        /// 获取枚举变量值的 Description 属性
        /// </summary>
        /// <param name="obj">枚举变量</param>
        /// <param name="isTop">是否改变为返回该类、枚举类型的头 Description 属性，而不是当前的属性或枚举变量值的 Description 属性</param>
        /// <returns>如果包含 Description 属性，则返回 Description 属性的值，否则返回枚举变量值的名称</returns>
        public static string GetDescription(this System.Enum obj, bool isTop)
        {
            if (obj == null)
                return string.Empty;
            try
            {
                Type enumType = obj.GetType();
                DescriptionAttribute dna = null;
                if (isTop)
                {
                    dna = (DescriptionAttribute)Attribute.GetCustomAttribute(enumType, typeof(DescriptionAttribute));
                }
                else
                {
                    FieldInfo fi = enumType.GetField(System.Enum.GetName(enumType, obj));
                    dna = (DescriptionAttribute)Attribute.GetCustomAttribute(
                       fi, typeof(DescriptionAttribute));
                }
                if ((dna != null) && (string.IsNullOrEmpty(dna.Description) == false))
                    return dna.Description;
            }
            catch
            {
                return string.Empty;
            }
            return obj.ToString();
        }
    }
}
