using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class MovementScript : MonoBehaviour
{
    #region Properties
    public bool letSprint = true;
    public bool letJump = true;
    public bool letCrouch = true;
    public float moveSpeed = 1.0f;
    public float maxSpeed = 5.0f;
    public float sprintMultiplier = 1.2f;
    public float crouchMultiplier = 0.7f;
    public float jumpForce = 5.0f;
    public float maxGroundAngle = 45.0f;
    public float crouchRate = 0.2f;
    #endregion

    #region Member variables
    protected Rigidbody _rb;
    protected CapsuleCollider _col;
    protected bool _isCrouching = false;
    protected bool _isSprinting = false;
    protected bool _isJumping = false;
    [SerializeField]protected bool _isGrounded = false;
    protected Vector3 _groundContactNormal;
    protected float _forwardVelocity = 0.0f;
    protected float _strafeVelocity = 0.0f;
    protected float _playerHeight;
    protected float _playerInitialScale;
    protected float _crouchPercent = 0.0f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Grab initial scale to use in crouching later on
        _playerInitialScale = transform.localScale.y;

        //Get Rigidbody component
        _rb = gameObject.GetComponent<Rigidbody>();

        //Grab the main collider of the object (intended to be a CapsuleCollider possibly on a child object) and use it's height as the player's height (used in crouching)
        _col = gameObject.GetComponentInChildren<CapsuleCollider>();
        _playerHeight = _col.height;
    }

    protected virtual void FixedUpdate()
    {
        CheckIfGrounded();
        UpdateMoveVelocity();
        HandleCrouching();
    }

    public virtual void MoveHorizontal(float value)
    {
        _strafeVelocity = value;
    }

    public virtual void MoveVertical(float value)
    {
        _forwardVelocity = value;
    }

    //Make the player jump
    public virtual void Jump(bool value)
    {
        if (value && letJump && _isGrounded)
        {
            _isJumping = true;
        }
    }

    //Toggles the players' sprint on
    public virtual void Sprint(bool value)
    {
        if (value && letSprint && !_isCrouching)
        {
            _isSprinting = true;
        }
        else
        {
            _isSprinting = false;
        }
    }

    protected virtual void UpdateMoveVelocity()
    {
        //Initialize moveVelocity to zero. 
        Vector3 desiredVelocity = Vector3.zero;

        //Modify input data to remove issue of faster movement on non-axes
        Vector2 inputVector = new Vector2(_forwardVelocity, _strafeVelocity);

        //Apply sprint effects if trying to sprint forwards.
        float localMaxSpeed = maxSpeed;
        if (_isSprinting && _forwardVelocity > 0.0f)
        {
            inputVector.x *= sprintMultiplier;
            localMaxSpeed *= sprintMultiplier;
        }

        //Combine the vectors of transform.forward and tranform.right to find the desired move vector.
        //Use modified input data stored in _forwardVelocity and _strafeVelocity as the scalars for these vectors, respectively.
        desiredVelocity = transform.forward * inputVector.x + transform.right * inputVector.y;
        desiredVelocity.y = 0.0f;

        //Scale velocity by moveSpeed
        desiredVelocity *= moveSpeed;

        //Scale velocity by crouch multiplier if the player is crouching
        if (_isCrouching)
        {
            desiredVelocity *= crouchMultiplier;
            localMaxSpeed *= crouchMultiplier;
        }

        float yVel = _rb.velocity.y;
        _rb.velocity *= 0.5f;

        //Apply x/y plane velocity
        //First, clamp it so you can't excede maxSpeed
        if((_rb.velocity + desiredVelocity).sqrMagnitude > localMaxSpeed * localMaxSpeed)
        {
            desiredVelocity = desiredVelocity.normalized * localMaxSpeed;
        }
        else
        {
            desiredVelocity += _rb.velocity;
        }

        if (_isJumping)
        {
            desiredVelocity.y = jumpForce;
            _isJumping = false;
            _isGrounded = false;
        }
        else
        {
            desiredVelocity.y = yVel;
        }

        _rb.velocity = desiredVelocity;
    }

    //Crouches the player when held
    public virtual void Crouch(bool value)
    {
        if (!letCrouch) { return; }
        //If currently crouching and the crouch button isn't being held, try to stand up
        //Else crouch.

        if (_isCrouching && !value)
        {
            //Prepare data for use in CheckCapsule()
            Vector3 p1 = _col.transform.position;
            Vector3 p2 = p1 + (Vector3.up * _playerHeight * 0.524f);
            float checkRadius = _col.radius * 0.9f;
            int layermask = 1 << LayerMask.NameToLayer("Player");
            layermask = ~layermask;

            //Check to see if the player has enough room to stand up
            bool didCollide = Physics.CheckCapsule(p1, p2, checkRadius, layermask, QueryTriggerInteraction.Ignore);
            //If there's nothing in their way, let the player stop crouching
            if (!didCollide)
            {
                _isCrouching = false;
            }
        }
        else if (value)
        {
            _isCrouching = true;
        }
    }

    protected virtual void CheckIfGrounded()
    {
        //Prepare data for use in CheckSphere()
        Vector3 checkPos = _col.transform.position + _col.center;
        float checkDist = (_col.height / 2 - _col.radius) * transform.localScale.y * 1.1f;

        //If the player's feet are touching something, player is grounded
        RaycastHit hitInfo;
        _isGrounded = Physics.SphereCast(checkPos, _col.radius, Vector3.down, out hitInfo, checkDist, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore);
        
        if (_isGrounded)
        {
            //Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.yellow, 1.0f);

            //If ground is too steep (and also not classified as stairs) then the player isn't actually grounded
            _groundContactNormal = hitInfo.normal;
            if (hitInfo.collider.gameObject.tag.Contains("stairs"))
            {
                if (Vector3.Angle(Vector3.up, _groundContactNormal) > maxGroundAngle)
                {
                    _isGrounded = false;
                }
            }
        }
    }

    protected virtual void HandleCrouching()
    {
        float playerHeightScale = Mathf.Lerp(_playerInitialScale, _playerInitialScale * 0.5f, _crouchPercent);
        transform.localScale = new Vector3(1.0f, playerHeightScale, 1.0f);

        if (_isCrouching && _crouchPercent < 1.0f)
        {
            _crouchPercent += Time.fixedDeltaTime * crouchRate;
        }
        else if (!_isCrouching && _crouchPercent > 0.0f)
        {
            _crouchPercent -= Time.fixedDeltaTime * crouchRate;
        }
    }
}
