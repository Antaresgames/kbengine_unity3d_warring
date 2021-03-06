using UnityEngine;
using KBEngine;
using System.Collections;

public class backgroundpic : MonoBehaviour {

	public static UITexture obj = null;
	
	void Awake ()   
	{
		obj = GetComponent<UITexture>();
		StartCoroutine(getFullTexture());
	}
	
	// Use this for initialization
	void Start () {
	}
	 
	IEnumerator getFullTexture(){
		if(obj.mainTexture.name.IndexOf("_min") > -1)
		{
			string[] res = obj.mainTexture.name.Split(new char[]{'_', 'm', 'i', 'n'});
			string path = "/ui/bg/" + res[0] + ".jpg";
			Common.DEBUG_MSG("backgroundpic::getFullTexture: starting download backgroundpic! curr=" + obj.mainTexture.name);
			
			WWW www = new WWW(Common.safe_url(path));  
			yield return www; 
			
	        if (www.error != null)  
	            Common.ERROR_MSG(www.error);  
			else if(www.texture != null)
				obj.mainTexture = www.texture;
			
			Common.DEBUG_MSG("backgroundpic::getFullTexture: download backgroundpic is finished!");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
