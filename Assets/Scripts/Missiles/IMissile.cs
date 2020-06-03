using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMissile
{
   void Move();
   void Delete();
   void OnTriggerEnter2D(Collider2D collider);
}
