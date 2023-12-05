using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorders : MonoBehaviour
{
    [SerializeField]
    private Transform LeftBorder, RightBorder;
    /*points[0] - верхн€€ права€,
    points[1] - верхн€€ лева€,
    points[2] - нижн€€ лева€,
    points[3] - нижн€€ права€
    */

    private void Awake()
    {
        PolygonCollider2D polygon = GetComponent<PolygonCollider2D>();
        Vector2[] borders = { new Vector2(RightBorder.localPosition.x, LeftBorder.localPosition.y),
                                new Vector2(LeftBorder.localPosition.x, LeftBorder.localPosition.y),
                                new Vector2(LeftBorder.localPosition.x, RightBorder.localPosition.y),
                                new Vector2(RightBorder.localPosition.x, RightBorder.localPosition.y)};
        polygon.SetPath(0, borders);
    }
}
