//string[] frames = ["10,0", "1,4", "5,4", "3,3", "6,2", "10,0", "10,0", "8,2", "5,2", "3,6"];
//string[] frames = ["10,0", "10,0", "10,0", "10,0", "10,0", "10,0", "10,0", "10,0", "10,0", "10,0", "10,0"];
string[] frames = ["10,0", "10,0", "10,0", "10,0", "10,0", "10,0", "10,0", "10,0", "10,0", "10,0", "10,0"];
//string[] frames = ["9,0", "9,0", "9,0", "9,0", "9,0", "9,0", "9,0", "9,0", "9,0", "9,0"];
//string[] frames = ["5,5", "5,5", "5,5", "5,5", "5,5", "5,5", "5,5", "5,5", "5,5", "5,5", "5,5"];

int score = 0;

for (var i = 0; i < frames.Length; i++)
{
    var firstThrow = int.Parse(frames[i].Split(",")[0]);
    var secondThrow = int.Parse(frames[i].Split(",")[1]);

    // Calculate strike score
    if (firstThrow == 10)
    {
        // Skip bonus frame
        if (i == 10) break;
        var firstFrameFirstThrow = int.Parse(frames[i + 1].Split(",")[0]);
        var firstFrameSecondThrow = int.Parse(frames[i + 1].Split(",")[1]);
        if (firstFrameFirstThrow == 10)
        {
            var secondFrameFirstThrow = int.Parse(frames[i + 1].Split(",")[0]);
            var secondFrameSecondThrow = int.Parse(frames[i + 1].Split(",")[1]);
            score += 10 + firstFrameFirstThrow + firstFrameSecondThrow + secondFrameFirstThrow + secondFrameSecondThrow;
        }
        else
        {
            score += 10 + firstFrameFirstThrow + firstFrameSecondThrow;
        }
    }
    // Calculate spare throw
    else if (firstThrow + secondThrow == 10)
    {
        // Skip bonus frame
        if (i == 10) break;
        var nextFrameFirtsThrow = int.Parse(frames[i + 1].Split(",")[0]);
        score += 10 + nextFrameFirtsThrow;
    }
    // Calculate normal throw
    else
    {
        score += firstThrow + secondThrow;
    }
}

Console.WriteLine(score);