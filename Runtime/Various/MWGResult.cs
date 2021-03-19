namespace MWG
{
    public readonly struct MWGResult<T> where T : class
    {
        public readonly bool isSuccess;
        public readonly string errorMessage;
        private readonly T result;

        private MWGResult(bool isSuccess, string errorMessage, T result)
        {
            this.isSuccess = isSuccess;
            this.errorMessage = errorMessage;
            this.result = result;
        }

        public static MWGResult<T> Success(T result)
        {
            return new MWGResult<T>(
                true,
                string.Empty,
                result
            );
        }

        public static MWGResult<T> Failure()
        {
            return new MWGResult<T>(
                false,
                string.Empty,
                null
            );
        }

        public static MWGResult<T> Failure(string errorMessage)
        {
            return new MWGResult<T>(
                false,
                errorMessage,
                null
            );
        }

        public T Result()
        {
            MWGAssert.SuperAssert(
                result != null,
                $"Tried to access unsuccessful Result<{typeof(T)}.Result (didSucceed: {isSuccess}"
            );

            return result;
        }

        public static implicit operator bool(MWGResult<T> result)
        {
            return result.isSuccess;
        }
    }

    public readonly struct MWGResult
    {
        public readonly bool isSuccess;
        public readonly string errorMessage;

        private MWGResult(bool isSuccess, string errorMessage)
        {
            this.isSuccess = isSuccess;
            this.errorMessage = errorMessage;
        }

        public static MWGResult Success()
        {
            return new MWGResult(true, string.Empty);
        }

        public static MWGResult Failure(string message)
        {
            return new MWGResult(false, message);
        }

        public static implicit operator bool(MWGResult result)
        {
            return result.isSuccess;
        }
    }
}