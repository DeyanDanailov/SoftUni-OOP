

namespace P01.Stream_Progress
{
     public interface IStreamable
    {
        public int Length { get; }

        public int BytesSent { get; }
    }
}
