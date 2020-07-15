namespace TextAdventureProject.TextAdventureFramework
{
    abstract class BaseStoryOption
    {
        public string TargetKey;
        public abstract string DisplayText { get; }

        protected BaseStoryOption(string targetKey)
        {
            TargetKey = targetKey;
        }
    }
}
