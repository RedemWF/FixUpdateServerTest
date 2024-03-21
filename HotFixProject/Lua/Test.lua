local UnityEngine = CS.UnityEngine
local GameObject = UnityEngine.GameObject

xlua.hotfix(CS.Cube,'Update',function (self)
    if UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.S) then
        self._rigidbody:AddForce(UnityEngine.Vector3.up*500)
    end
end)
xlua.hotfix(CS.Load,'Start',function (self)
    self.hotFix:LoadResource('Sphere', '?filename=sphere.unity3d')
    --self.hotFix:LoadResource('Sphere','gameobject\\sphere.unity3d');
end)
xlua.hotfix(CS.Load,'Update',function (self)
    if UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.A) then
        GameObject.Instantiate(self.hotFix:GetPrefab('Sphere'))
    end
end)