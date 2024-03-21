using UnityEngine;
using XLua;
[Hotfix]
public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    [LuaCallCSharp]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody.AddForce(Vector3.up*500);
        }
    }
}
