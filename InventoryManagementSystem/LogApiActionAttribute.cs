using PostSharp.Aspects;
using Serilog;

namespace InventoryManagementSystem
{
    [Serializable]
    public class LogApiActionAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var controllerName = args.Method.DeclaringType?.Name;
            var actionName = args.Method.Name;
            var timestamp = DateTime.UtcNow;

            var logMessage = $"API Action: {controllerName}/{actionName}, Timestamp: {timestamp}";
            Log.Information(logMessage);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var controllerName = args.Method.DeclaringType?.Name;
            var actionName = args.Method.Name;
            var timestamp = DateTime.UtcNow;

            var logMessage = $"API Action: {controllerName}/{actionName}, Timestamp: {timestamp}";
            Log.Information(logMessage);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            var controllerName = args.Method.DeclaringType?.Name;
            var exceptionMessage = args.Exception.Message;

            var logMessage = $"Excepction happened in API {controllerName} with message: {exceptionMessage}";
            Log.Error(logMessage);
        }
    }
}
