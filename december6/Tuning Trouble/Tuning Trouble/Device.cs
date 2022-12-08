namespace Tuning_Trouble;

public class Device
{

    public int DetectStartOfPacketMarker(string inputString, int startMarkerLength)
    {
        // this seems like a problem that suits the sliding window approach
        // the end of the sliding window will get array out of bounds if loop is not exited at i - windowSize
        var input = inputString.ToCharArray();

        for (int i = 0; i <= input.Length - startMarkerLength; i++)
        {
            var windowContent = new ReadOnlySpan<char>(input, i, startMarkerLength);
            var distinctChars = new HashSet<char>();

            foreach (var character in windowContent)
            {
                distinctChars.Add(character);
                if (distinctChars.Count == startMarkerLength)
                    return i + startMarkerLength;
            }
        }

        return -1;  // nothing found
    }
}