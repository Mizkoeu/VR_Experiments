using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour {

    public float rotateSpeed;
    public float moveSpeed;
    private Vector3 direction;

    IEnumerator Rotate(Quaternion startRotation, Quaternion newRotation) {
        float interpolate = 0f;
        Debug.Log(transform.rotation.eulerAngles + " and the new one is " + newRotation.eulerAngles);
        while (interpolate <= 1f) {
            transform.rotation = Quaternion.LerpUnclamped(startRotation, newRotation, interpolate);
            interpolate += Time.deltaTime * rotateSpeed;
            yield return null;
        }
        transform.rotation = newRotation;
    }

    IEnumerator Move(Vector3 startPos, Vector3 newPos) {
        float interpolate = 0f;
        while (interpolate <= 1f) {
            transform.position = Vector3.LerpUnclamped(startPos, newPos, interpolate);
            interpolate += Time.deltaTime * moveSpeed;
            yield return null;
        }
        transform.position = newPos;
    }

	// Use this for initialization
	void Start () {
        direction = new Vector3(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W)) {
            direction = new Vector3(0f, 0f, 1f);
        } else if (Input.GetKeyDown(KeyCode.S)){
            direction = new Vector3(0f, 0f, -1f);
        } else if (Input.GetKeyDown(KeyCode.A)){
            direction = new Vector3(-1f, 0f, 0f);
        } else if (Input.GetKeyDown(KeyCode.D)){
            direction = new Vector3(1f, 0f, 0f);
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            Quaternion newRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
            StartCoroutine(Rotate(transform.rotation, newRotation));
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 8f, ForceMode.Impulse);
        } else {
            direction = new Vector3(0f, 0f, 0f);
        }

        //transform.Translate(direction * Time.deltaTime);
        if (!direction.Equals(Vector3.zero)) {
            StartCoroutine(Move(transform.position, transform.position + direction));
        }
    }
}
