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
        /// �Ա�
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
        [EnumAlias(Language.ja_JP, "�i��")]
        [EnumAlias(Language.en_US, "Read")]
        [EnumAlias(Language.zh_CN, "�Ķ�")]
        Read = 1,

        [EnumAlias(Language.ja_JP, "�饤�ƥ���")]
        [EnumAlias(Language.en_US, "Writing")]
        [EnumAlias(Language.zh_CN, "д��")]
        Writing = 2,

        [EnumAlias(Language.ja_JP, "���祮��")]
        [EnumAlias(Language.en_US, "Running")]
        [EnumAlias(Language.zh_CN, "�ܲ�")]
        Running = 4,
    }

    public enum Gender
    {
        [EnumAlias(Language.ja_JP, "��")]
        [EnumAlias(Language.en_US, "Male")]
        [EnumAlias(Language.zh_CN, "��")]
        Boy,

        [EnumAlias(Language.ja_JP, "Ů")]
        [EnumAlias(Language.en_US, "Female")]
        [EnumAlias(Language.zh_CN, "Ů")]
        Girl,
    }

    public enum Country
    {
        [EnumAlias(Language.ja_JP, "������")]
        [EnumAlias(Language.en_US, "China")]
        [EnumAlias(Language.zh_CN, "�й�")]
        China,

        [EnumAlias(Language.ja_JP, "�ձ�")]
        [EnumAlias(Language.en_US, "Japan")]
        [EnumAlias(Language.zh_CN, "�ձ�")]
        Japan,

        [EnumAlias(Language.ja_JP, "�׹�")]
        [EnumAlias(Language.en_US, "American")]
        [EnumAlias(Language.zh_CN, "����")]
        American,
    }
}
