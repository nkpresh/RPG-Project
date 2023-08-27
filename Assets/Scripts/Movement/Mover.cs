using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;

        Ray lastRay;
        NavMeshAgent agent;
        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {


            UpdateAnimator();
            //Debug.DrawRay(lastRay.origin, lastRay.direction*100);
            //agent.destination=target.position;
        }

        // private void MoveToCursor()
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     bool hasHit = Physics.Raycast(ray, out hit);
        //     if (hasHit)
        //     {
        //         MoveTo(hit.point);
        //     }
        // }

        public void MoveTo(Vector3 destination)
        {
            agent.destination = destination;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }
    }

}