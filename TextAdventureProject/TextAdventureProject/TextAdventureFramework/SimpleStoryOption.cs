using System;

namespace TextAdventureProject.TextAdventureFramework
{
    class SimpleStoryOption : BaseStoryOption
    {
        public string OptionText;
        public override string DisplayText => OptionText;

        public SimpleStoryOption(string targetKey, string text) : base(targetKey)
        {
            OptionText = text;
        }
    }
}
