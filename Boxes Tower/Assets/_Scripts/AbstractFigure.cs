using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFigure : MonoBehaviour
{
    [SerializeField] float _springDistance;
    [SerializeField] float _springDampingRatio;
    [SerializeField] float _springFraquency;
    [SerializeField] bool _springEnableCollision;
    [SerializeField] int _points;

    public int Points
    {
        get
        {
            return _points;
        }

        set
        {
            _points = value;
        }
    }

    /// <summary>
    /// Set distance, dampingRatio, frequency, enableCollision
    /// </summary>
    /// <param name="spring"></param>
    /// <returns></returns>
    public SpringJoint2D SetSpringJoint2D(SpringJoint2D spring)
    {
        spring.autoConfigureDistance = false;
        spring.distance = _springDistance;
        spring.dampingRatio = _springDampingRatio;
        spring.frequency = _springFraquency;
        spring.enableCollision = true;
        return spring;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.transform.position.y > Camera.main.transform.position.y)
        {
            Camera.main.GetComponent<CameraScript>().MoveCamera(collision.gameObject.transform.position);            
        }
    }

};
