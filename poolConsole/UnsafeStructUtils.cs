namespace poolConsole;

public static class UnsafeStructUtils
{
    private static char[] _poolTagChars = new char[4];
    
    public static unsafe string FormatPoolTag(SystemPoolTag tag)
    {
        var tagString = System.Text.Encoding.ASCII.GetString(tag.Tag.Tag, 4);
        return
            $"Tag: {tagString}, PagedAllocs: {tag.PagedAllocs}, PagedFrees: {tag.PagedFrees}, PagedUsed: {tag.PagedUsed}, NonPagedAllocs: {tag.NonPagedAllocs}, NonPagedFrees: {tag.NonPagedFrees}, NonPagedUsed: {tag.NonPagedUsed}";
    }
}