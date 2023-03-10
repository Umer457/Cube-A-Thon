using System.Linq;
using Altom.AltUnityDriver;
using Altom.AltUnityDriver.Commands;

namespace Altom.AltUnityTester.Commands
{
    class AltUnityFindObjectCommand : AltUnityBaseClassFindObjectsCommand<AltUnityObject>
    {
        public AltUnityFindObjectCommand(BaseFindObjectsParams cmdParam) : base(cmdParam) { }

        public override AltUnityObject Execute()
        {
            var path = new PathSelector(CommandParams.path);
            var foundGameObject = FindObjects(null, path.FirstBound, true, CommandParams.enabled);
            UnityEngine.Camera camera = null;
            if (!CommandParams.cameraPath.Equals("//"))
            {
                camera = GetCamera(CommandParams.cameraBy, CommandParams.cameraPath);
                if (camera == null) throw new CameraNotFoundException();
            }
            if (foundGameObject.Count() == 1)
            {
                return
                    AltUnityRunner._altUnityRunner.GameObjectToAltUnityObject(foundGameObject[0], camera);
            }
            throw new NotFoundException(string.Format("Object {0} not found", CommandParams.path));
        }
    }
}
