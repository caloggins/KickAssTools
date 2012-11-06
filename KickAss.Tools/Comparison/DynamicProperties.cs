namespace KickAss.Tools.Comparison
{
    using System.Collections.Generic;
    using System.Linq;
    using ImpromptuInterface;

    public static class DynamicProperties
    {
        public static bool AreEqual(dynamic source, dynamic target)
        {
            IEnumerable<string> list1 = Impromptu.GetMemberNames(source);
            list1 = list1.OrderBy(m => m);
            IEnumerable<string> list2 = Impromptu.GetMemberNames(target);
            list2 = list2.OrderBy(m => m);

            if (!list1.SequenceEqual(list2))
                return false;

            return list1.All(memberName => Impromptu.InvokeGet(source, memberName).Equals(Impromptu.InvokeGet(target, memberName)));
        }
    }
}