using System;
using System.Collections.Generic;
using UniVue.i18n;
using UniVue.Model;
using UniVue.ViewModel;

namespace UniVue.Test
{
    [Bindable]
    public sealed partial class Player
    {
        private string _name;
        private List<string> _language;
    }

    [Bindable]
    public sealed partial class User
    {
        /// <summary>
        /// 性别
        /// </summary>
        private Gender _gender;
        private Hobby _hobby;
        private Country _country;
        private List<string> _language;
    }

    [Bindable]
    public sealed partial class ItemData
    {
        [PropertyName("ID")]
        private int _id;
    }

    [Flags]
    public enum Hobby
    {
        [EnumAlias(Language.ja_JP, "読む")]
        [EnumAlias(Language.en_US, "Read")]
        [EnumAlias(Language.zh_CN, "阅读")]
        Read = 1,

        [EnumAlias(Language.ja_JP, "ライティング")]
        [EnumAlias(Language.en_US, "Writing")]
        [EnumAlias(Language.zh_CN, "写作")]
        Writing = 2,

        [EnumAlias(Language.ja_JP, "ジョギング")]
        [EnumAlias(Language.en_US, "Running")]
        [EnumAlias(Language.zh_CN, "跑步")]
        Running = 4,
    }

    public enum Gender
    {
        [EnumAlias(Language.ja_JP, "男")]
        [EnumAlias(Language.en_US, "Male")]
        [EnumAlias(Language.zh_CN, "男")]
        Boy,

        [EnumAlias(Language.ja_JP, "女")]
        [EnumAlias(Language.en_US, "Female")]
        [EnumAlias(Language.zh_CN, "女")]
        Girl,
    }

    public enum Country
    {
        [EnumAlias(Language.ja_JP, "ズガハ")]
        [EnumAlias(Language.en_US, "China")]
        [EnumAlias(Language.zh_CN, "中国")]
        China,

        [EnumAlias(Language.ja_JP, "日本")]
        [EnumAlias(Language.en_US, "Japan")]
        [EnumAlias(Language.zh_CN, "日本")]
        Japan,

        [EnumAlias(Language.ja_JP, "米国")]
        [EnumAlias(Language.en_US, "American")]
        [EnumAlias(Language.zh_CN, "美国")]
        American,
    }
}
