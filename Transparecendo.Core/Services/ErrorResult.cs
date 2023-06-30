using Transparecendo.Core.Extensions;

namespace Transparecendo.Core.Services
{
    public class ErrorResult : Result, IErrorResult
    {
        public ErrorResult() : base(false)
        {
            Errors = new List<ErrorEntity>();
        }

        public ErrorResult(List<ErrorEntity> errors) : base(false)
        {
            Errors = errors;
        }

        public ErrorResult(Enum errorCode) : this()
        {
            BindErrors(new[] { errorCode });
        }

        public ErrorResult(IEnumerable<Enum> errorCodes) : this()
        {
            BindErrors(errorCodes);
        }

        public List<ErrorEntity> Errors { get; private set; }

        protected virtual void BindErrors<T>(IEnumerable<string> errorsCode, params object[] paramReplace) where T : struct
        {
            foreach (var item in errorsCode)
            {
                var metaError = Enum.Parse(typeof(T), item).createMetaError(paramReplace);
                Errors.Add(metaError.Error);
            }
        }

        protected virtual void BindErrors<T>(IEnumerable<T> errorsCode, params object[] paramReplace) where T : struct
        {
            foreach (var item in errorsCode)
            {
                var metaError = item.createMetaError(paramReplace);
                Errors.Add(metaError.Error);
            }
        }

        protected virtual void BindErrors(IEnumerable<Enum> errorsCode, params object[] paramReplace)
        {
            BindErrors(this, errorsCode, paramReplace);
        }

        public static void BindErrors(IErrorResult errorData, IEnumerable<Enum> errorsCode, params object[] paramReplace)
        {
            foreach (var item in errorsCode)
            {
                var metaError = item.createMetaError(paramReplace);
                errorData.Errors.Add(metaError.Error);
            }
        }
    }

    public class ErrorResult<T> : ErrorResult where T : struct
    {
        public ErrorResult() : base()
        {
        }

        public ErrorResult(List<string> errorsCode) : base()
        {
            BindErrors<T>(errorsCode);
        }

        public ErrorResult(string errorCode) : base()
        {
            BindErrors<T>(new List<string>() { errorCode });
        }

        public ErrorResult(Enum errorCode) : base(errorCode)
        {

        }

        public ErrorResult(IEnumerable<Enum> errorCodes) : base(errorCodes)
        {

        }

        public ErrorResult(T errorCode) : base()
        {
            BindErrors(new[] { errorCode });
        }

        public ErrorResult(List<T> errorCode) : base()
        {
            BindErrors(errorCode);
        }

        public ErrorResult(T errorCode, params object[] paramReplace) : base()
        {
            BindErrors(new[] { errorCode }, paramReplace);
        }

        public ErrorResult(string errorCode, params object[] paramReplace) : base()
        {
            BindErrors<T>(new[] { errorCode }, paramReplace);
        }
    }

    public class ResponseErrorResult<T> : Result<T>, IErrorResult
    {
        public ResponseErrorResult() : base()
        {
            Errors = new List<ErrorEntity>();
        }

        public ResponseErrorResult(Enum errorCode) : this()
        {
            ErrorResult.BindErrors(this, new[] { errorCode });
        }

        public ResponseErrorResult(IEnumerable<Enum> errorCodes) : this()
        {
            ErrorResult.BindErrors(this, errorCodes);
        }

        public ResponseErrorResult(Enum errorCode, object paramReplace) : this()
        {
            ErrorResult.BindErrors(this, new[] { errorCode }, paramReplace);
        }

        public List<ErrorEntity> Errors { get; private set; }
    }

    public class ErrorResult<TEnum, TRequest> : ErrorResult<TEnum> where TEnum : struct where TRequest : class
    {
        public ErrorResult(List<string> errorsCode) : base()
        {
            BindErrors<TEnum>(errorsCode);
        }

        public ErrorResult(string errorCode) : base()
        {
            BindErrors<TEnum>(new[] { errorCode });
        }

        public ErrorResult(TEnum errorCode) : base()
        {
            BindErrors(new[] { errorCode });
        }

        public ErrorResult(List<TEnum> errorCode) : base()
        {
            BindErrors(errorCode);
        }

        public ErrorResult(TEnum errorCode, object paramReplace) : base()
        {
            BindErrors(new[] { errorCode }, paramReplace);
        }

        public ErrorResult(string errorCode, object paramReplace) : base()
        {
            BindErrors<TEnum>(new[] { errorCode }, paramReplace);
        }

        protected override void BindErrors<T>(IEnumerable<string> errorsCode, params object[] paramReplace) where T : struct
        {
            foreach (var item in errorsCode)
            {
                var metaError = Enum.Parse<T>(item).createMetaError(paramReplace);
                Errors.Add(metaError.Error);
            }
        }

        protected override void BindErrors<T>(IEnumerable<T> errorsCode, params object[] paramReplace) where T : struct
        {
            foreach (var item in errorsCode)
            {
                var metaError = item.createMetaError(paramReplace);
                Errors.Add(metaError.Error);
            }
        }
    }

    public interface IErrorResult
    {
        List<ErrorEntity> Errors { get; }
    }
}
