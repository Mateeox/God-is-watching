using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeMode : MonoBehaviour
{
    [SerializeField]
    public Camera heroCam;
    [SerializeField]
    public Camera godCam;

    public float distance = 30f;
    public float speed = 100f;
    public float angle = 15f;
    public int hideLayer = 8;

    private bool _animation = false;
    private Camera _cam;
    private Vector3 _lastPos;
    private List<Vector3> _animtionsPos;

    void Start()
    {
        _animtionsPos = new List<Vector3>();
        godCam.cullingMask = 7 << 0;
    }

    void Update()
    {

        //Change camera during changing game mode
        if (Input.GetButtonDown("ChangeMode"))
        {
            DisableAll();
            if (_animation)
            {
                _animtionsPos.Clear();
                _animtionsPos.Add(_lastPos);
            }
            else
            {
                if (GameVariables.GameMode == GameVariables.GameModes.God)
                    AnimationToGod(heroCam, godCam);
                else
                    AnimationToHero(heroCam, godCam);
            }
        }

        if (_animation)
        {
            Animate(_cam);
        }
    }

    private void DisableAll()
    {
        heroCam.enabled = false;
        godCam.enabled = false;
    }

    private void Enable()
    {
        if (GameVariables.GameMode == GameVariables.GameModes.God)
        {
            godCam.enabled = true;
        }
        else
        {
            heroCam.enabled = true;
        }
    }
    private List<GameObject> _list;
    private float _distance;
    private void AnimationToGod(Camera heroCam, Camera godCam)
    {
        _lastPos = heroCam.transform.position;
        Vector3 playerPos = heroCam.transform.position;
        _cam = Component.Instantiate<Camera>(godCam);
        _cam.GetComponent<GodCamera>().SetAnimation(true);
        _cam.transform.position = playerPos;
        _cam.transform.rotation = heroCam.transform.rotation;
        //GameObject[] array = GameObject.FindObjectsOfType<GameObject>();
        //_list = new List<GameObject>();
        //foreach (GameObject obj in array)
        //{
        //    if (obj.layer == hideLayer)
        //        _list.Add(obj);
        //}
        _cam.enabled = true;
        //Vector3 angles = _cam.transform.rotation.eulerAngles;
        //_animtionsPos.Add(new Vector3(-1.0f * (Mathf.Cos(angles.y / 180 * Mathf.PI)) * 5.0f + playerPos.x, -1.0f * (Mathf.Sin(angles.y / 180 * Mathf.PI) * 5.0f) + playerPos.y, playerPos.z));
        Vector3 pos;
        pos = new Vector3(Mathf.Cos(angle / 180 * Mathf.PI) * distance + playerPos.x, Mathf.Sin(angle / 180 * Mathf.PI) * distance + playerPos.y, playerPos.z);
        _animtionsPos.Add(pos);
        godCam.transform.position = pos;
        godCam.transform.rotation = new Quaternion(-0.1f, 0.7f, -0.1f, -0.7f);
        //_distance = Vector3.Distance(playerPos, pos);
        Animate(_cam);
    }

    private void AnimationToHero(Camera heroCam, Camera godCam)
    {
        _lastPos = godCam.transform.position;
        Vector3 playerPos = heroCam.transform.position;
        _cam = Component.Instantiate<Camera>(godCam);
        _cam.enabled = true;
        _animtionsPos.Add(heroCam.transform.position);
        _distance = 1.0f;
        Animate(_cam);
    }

    public void Animate(Camera cam)
    {
        _animation = true;

        if (_animtionsPos.Count > 0 && !CheckPosition(_animtionsPos[0], cam.transform.position))
        {
            //foreach (GameObject obj in _list)
            //{
            //    foreach (Material m in obj.GetComponent<Renderer>().materials)
            //    {
            //        SetMaterialTransparent(m);
            //        m.color = new Color(1.0f, 1.0f, 1.0f, Vector3.Distance(cam.transform.position, _animtionsPos[0]) / distance);
            //    }
            //}
            Vector3 vector = Vector3.MoveTowards(cam.transform.position, _animtionsPos[0], 0.01f * speed / (Mathf.Pow(3.0f, _animtionsPos.Count)));
            cam.transform.position = vector;
            cam.transform.LookAt(heroCam.transform.position);
        }
        else
        {
            _animtionsPos.RemoveAt(0);
        }
        if (_animtionsPos.Count == 0)
        {
            _animation = false;
            cam.enabled = false;
            Enable();
            DestroyImmediate(cam.gameObject);
        }
    }

    //private void SetMaterialTransparent(Material m)
    //{
    //    m.SetFloat("_Mode", 2);
    //    m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
    //    m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
    //    m.SetInt("_ZWrite", 0);
    //    m.DisableKeyword("_ALPHATEST_ON");
    //    m.EnableKeyword("_ALPHABLEND_ON");
    //    m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
    //    m.renderQueue = 3000;
    //}

    //private void SetMaterialOpaque(Material m)
    //{
    //    m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
    //    m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
    //    m.SetInt("_ZWrite", 1);
    //    m.DisableKeyword("_ALPHATEST_ON");
    //    m.DisableKeyword("_ALPHABLEND_ON");
    //    m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
    //    m.renderQueue = -1;
    //}

    private bool CheckPosition(Vector3 current, Vector3 target)
    {
        if (current.normalized == target.normalized)
            return true;
        else
            return false;
    }
}
