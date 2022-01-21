using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SelectManager : MonoBehaviour
{
    //                               ������ : 2021/12/16                                   //
    //                               �����ð� : 14 : 30                                    //
    //                               ��� : �����                                         //
    //                               ��� : ���� ��� 

    [Header("Selected Knights")]
    [SerializeField] List<GameObject> selected_table = new List<GameObject>(); // ������ ������Ʈ�� ��� ����Ʈ
    public List<GameObject> Selected_table
    {
        get
        {
            return selected_table;
        }
    }


    [SerializeField] private bool selected = false;

    private RaycastHit hit = default;

    private Deployment deployment = null;
    private MeshCollider selectionBox = null;
    private Mesh selectionMesh = null;

    private Vector2[] corners = default;  // ������
    private Vector3[] sverts = default; // �������� ��ġ
    private Vector3[] svecs = default; // ����ü ���� ����

    private bool isPickMode = false;
    private void Start()
    {
        deployment = this.GetComponent<Deployment>();
    }

    public void OnSingleSelect(Vector3 _p1)// �巡�װ� �ƴ� ���� ����
    {
        
        Ray ray = Camera.main.ScreenPointToRay(_p1);

        // ���콺 �ٿ��� �� ���콺 �������� ���̷� ������
        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                // ������Ʈ �߰� ����
                if (!hit.transform.gameObject.GetComponent<Outlines>().enabled)
                {
                    Select(hit.transform.gameObject);

                }
                else
                    SingleInitialization(hit.transform.gameObject);
            }
            else
            {
                if (!EventSystem.current.IsPointerOverGameObject(-1))
                {
                    if (!hit.transform.gameObject.GetComponent<Outlines>().enabled)
                    {
                        
                        
                        ListInitialization();
                        Select(hit.transform.gameObject);
                        

                    }
                    else
                    {
                        if(selected_table.Count > 1)
                        {
                            ListInitialization();
                            Select(hit.transform.gameObject);
                        }
                        else
                        {
                            ListInitialization();
                        } 
                    }
                }
                // �ٸ� ������Ʈ�� ���� ��
                //Select(hit.transform.gameObject);
            }
        }
        else 
        {
            // �ƹ��͵� ��Ʈ��Ų ���� ���� ��
            if (Input.GetKey(KeyCode.LeftShift))
            {
                return;
            }
            else
            {
                if (!EventSystem.current.IsPointerOverGameObject(-1))
                    ListInitialization();

            }
        }
        selected = selected_table.Count > 0 ? true : false;
    }
    public void OnBattleSingleSelect(Vector3 _p1)// �巡�װ� �ƴ� ���� ����
    {

        Ray ray = Camera.main.ScreenPointToRay(_p1);

        // ���콺 �ٿ��� �� ���콺 �������� ���̷� ������
        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))
        {

            // �ٸ� ������Ʈ�� ���� ��
            if (!EventSystem.current.IsPointerOverGameObject(-1))
            {

                ListInitialization();
                Select(hit.transform.gameObject);
            }

        }
        else
        {
             if (!EventSystem.current.IsPointerOverGameObject(-1))
                 ListInitialization();  
        }
        selected = selected_table.Count > 0 ? true : false;
    }

    private void Select(GameObject _hit)// ���� �� �������
    {
        selected_table.Add(_hit);
        _hit.GetComponent<Outlines>().enabled = true;
    }

    public bool IsSelected()
    {
        return selected;
    }
    public void SetSelected(bool _isSelected)
    {
        selected = _isSelected;
    }
    public void OnListSelect(KnightInformation _selectListKnights)// �巡�װ� �ƴ� ���� ����
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            SelectList(_selectListKnights);
        }
        else
        {
            ListInitialization();
            SelectList(_selectListKnights);
        }
        
        selected = selected_table.Count > 0 ? true : false;
    }

    public void SelectList(KnightInformation _selectListKnights)// ���� �� �������
    {
        selected_table.Add(_selectListKnights.transform.parent.gameObject);
        //Debug.Log(_selectListKnights.KnightName + " ����Ʈ ���� " + selected_table.Count + " ������ ���̺��� ��� ��");
        _selectListKnights.transform.parent.gameObject.GetComponent<Outlines>().enabled = true;
    }

    public void ListInitialization()// ����Ʈ �ʱ�ȭ 
    {
        for (int i = 0; i < selected_table.Count; i++)
        {
            selected_table[i].GetComponent<Outlines>().enabled = false;
            deployment.HologramActive(i,false);
        }
        selected_table.Clear();
    } 
    public void SingleInitialization(GameObject _go)
    {

        for(int i = 0; i < selected_table.Count; i++)
        {
            if(selected_table[i] == _go)
            {
                // ����
                selected_table[i].GetComponent<Outlines>().enabled = false;
                selected_table.RemoveAt(i);
            }
        }
    }

    public bool IsListSelected(KnightInformation _go)
    {
        for (int i = 0; i < selected_table.Count; i++)
        {
            if (selected_table[i] == _go.gameObject)
            {
                return true;
            }

        }
        return false;
    }

    public bool GetPickMode()
    {
        return isPickMode;
    }
    public void SetPickMode(bool _bool)
    {
        isPickMode = _bool;
    }
    public void OnDragSelect(Vector3 _p1, Vector3 _p2)//�巡�׷� ������ �� 
    {
        #region ���õ巡�׹ڽ� �׸������� �غ�
        // �巡�� �϶�
        sverts = new Vector3[4];
        // �� 4��
        svecs = new Vector3[4];
        //�׶���� ��� �� 4��


        int i = 0;

        // �� p2�� ���콺 ������
        corners = GetBoundingBox(_p1, _p2);


        foreach(Vector2 corner in corners)
        {
            Ray ray = Camera.main.ScreenPointToRay(corner);

            // ���̸� �簢���� ���������� ��
            if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 10)))
            {


                // ���̾ ������ 10�� �κи� hit
                // �������� ��ġ
                sverts[i] = hit.point;

                // ����ü ���� ����
                svecs[i] = ray.origin - hit.point;


                Debug.DrawLine(Camera.main.ScreenToWorldPoint(corner), sverts[i], Color.red, 1.0f);
            }
            i++;
        }
        selectionMesh = GenerateSelectionMesh(sverts, svecs);
        selectionBox = gameObject.AddComponent<MeshCollider>();


        selectionBox.sharedMesh = selectionMesh;
        selectionBox.convex = true;
        selectionBox.isTrigger = true;

        Destroy(selectionBox, 0.02f);
        #endregion
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            // ���ʽ���Ʈ�� ������ ���� �� 
            for (int k = 0; k < selected_table.Count; k++)
            {
                selected_table[k].GetComponent<Outlines>().enabled = false;
                deployment.HologramActive(k, false);
            }
            selected_table.Clear();
        }
        
    } 

    public void Pick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 50000.0f, (1 << 8)))
        {
            Debug.DrawRay(hit.point, Vector3.up*5,Color.cyan,0.1f);
            Vector3 hitPos = hit.point;
            selected_table[0].transform.position = hitPos + Vector3.up;
        }
    }


    // ��ġ�� �´� ������ ����� 
    private Vector2[] GetBoundingBox(Vector2 p1, Vector2 p2)
    {
        Vector2 newP1;
        Vector2 newP2;
        Vector2 newP3;
        Vector2 newP4;

        if (p1.x < p2.x) //if p1 is to the left of p2
        {
            if (p1.y > p2.y) // if p1 is above p2
            {
                newP1 = p1;
                newP2 = new Vector2(p2.x, p1.y);
                newP3 = new Vector2(p1.x, p2.y);
                newP4 = p2;
            }
            else //if p1 is below p2
            {
                newP1 = new Vector2(p1.x, p2.y);
                newP2 = p2;
                newP3 = p1;
                newP4 = new Vector2(p2.x, p1.y);
            }
        }
        else //if p1 is to the right of p2
        {
            if (p1.y > p2.y) // if p1 is above p2
            {
                newP1 = new Vector2(p2.x, p1.y);
                newP2 = p1;
                newP3 = p2;
                newP4 = new Vector2(p1.x, p2.y);
            }
            else //if p1 is below p2
            {
                newP1 = p2;
                newP2 = new Vector2(p1.x, p2.y);
                newP3 = new Vector2(p2.x, p1.y);
                newP4 = p1;
            }

        }

        Vector2[] corners = { newP1, newP2, newP3, newP4 };
        return corners;

    }


    // �浹�� ���� �ڽ� �����
    private Mesh GenerateSelectionMesh(Vector3[] corners, Vector3[] vecs)
    {
        Vector3[] verts = new Vector3[8];
        int[] tris = 
            { 0, 1, 2,
            2, 1, 3,
            4, 6, 0,
            0, 6, 2,
            6, 7, 2,
            2, 7, 3,
            7, 5, 3,
            3, 5, 1,
            5, 0, 1,
            1, 4, 0,
            4, 5, 6,
            6, 5, 7 }; //map the tris of our cube

        for (int i = 0; i < 4; i++)
        {
            verts[i] = corners[i];
        }

        for (int j = 4; j < 8; j++)
        {
            verts[j] = corners[j - 4] + vecs[j - 4];
        }

        Mesh selectionMesh = new Mesh();
        selectionMesh.vertices = verts;
        selectionMesh.triangles = tris;

        return selectionMesh;
    }
     

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            if (!other.gameObject.GetComponent<Outlines>().enabled)
            {
                selected_table.Add(other.gameObject);
                //uiManager.SynchronizationList(selected_table);
                other.transform.gameObject.GetComponent<Outlines>().enabled = true;
                selected = true;
            }
            else
            {
                if (selected_table.Count == 0)
                    selected = false;
                SingleInitialization(other.gameObject);
            }
        }
    }
}