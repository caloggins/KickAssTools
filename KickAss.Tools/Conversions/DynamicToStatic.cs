namespace KickAss.Tools.Conversions
{
    using System;
    using ImpromptuInterface;

    /// <summary>
    /// Used to convert a dynamic object to a instance class.
    /// </summary>
    public static class DynamicToStatic
    {
        public static T ToStatic<T>(dynamic source)
        {
            var entity = Activator.CreateInstance<T>();

            var properties = Impromptu.GetMemberNames(source);

            if (properties == null)
                return entity;

            foreach (var entry in properties)
            {
                var value = Impromptu.InvokeGet(source, entry);
                Impromptu.InvokeSet(entity, entry, value);
            }

            return entity;
        }
    }
}