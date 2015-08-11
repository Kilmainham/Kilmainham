
using UnityEngine;
using System.IO;
using System.Collections.Generic;

//public enum MegaCacheParticleMode
//{
	//Emit,
	//Playback,
//}

public class MegaCacheParticle : MonoBehaviour
{
	public MegaCacheParticleImage	image;
	public int						framenum;
	public float					time				= 0.0f;
	public int						maxparticles		= 1000;
	public float					fps					= 25.0f;
	public float					speed				= 1.0f;
	public MegaCacheRepeatMode		loopmode			= MegaCacheRepeatMode.Loop;
	public float					importscale			= 1.0f;
	public bool						animate				= false;
	public string					lastpath			= "";
	public bool						pos					= true;
	public bool						vel					= true;
	public bool						rot					= true;
	public bool						scale				= true;
	public bool						life				= true;
	public bool						age					= true;
	public bool						spin				= true;
	public float					scaleall			= 1.0f;
	public float					emitscale			= 1.0f;
	public float					emitrate			= 1.0f;
	public float					emitspeed			= 1.0f;
	public bool						useemit				= false;
	public float					sizescale			= 1.0f;
	public bool						prewarm				= false;
	public MegaCacheParticle		cachesrc			= null;
	public bool						optimize			= true;
	public bool						savevel				= true;
	public bool						saverot				= true;
	public bool						savescale			= true;
	public bool						savespin			= true;
	public int						particleindex		= 0;
	public int						emitcount			= 1;
	public List<int>				activeparticles		= new List<int>();
	public List<int>				removeparticles		= new List<int>();
	public bool						showpaths			= false;
	public int						showparticlestep	= 40;
	public int						showposstep			= 4;
	public int						showstart			= 0;
	public Color					showcolor			= Color.white;
	public MegaCacheAxis			axis				= MegaCacheAxis.Z;
	public List<MegaCacheParticleState>	states			= new List<MegaCacheParticleState>();
	//public MegaCacheParticleMode	mode				= MegaCacheParticleMode.Emit;
	public bool						removealive			= false;

	public virtual MegaCacheParticleImage GetImage()
	{
		return image;
	}

	public Vector3 DecodeV3(byte[] buffer, int ix, Vector3 min, Vector3 size)
	{
		Vector3 p;

		p.x = min.x + ((float)System.BitConverter.ToUInt16(buffer, ix) * size.x);
		p.y = min.y + ((float)System.BitConverter.ToUInt16(buffer, ix + 2) * size.y);
		p.z = min.z + ((float)System.BitConverter.ToUInt16(buffer, ix + 4) * size.z);

		return p;
	}

	public Vector3 DecodeV3b(byte[] buffer, int ix, Vector3 min, Vector3 size)
	{
		Vector3 p;

		p.x = min.x + ((float)buffer[ix] * size.x);
		p.y = min.y + ((float)buffer[ix + 1] * size.y);
		p.z = min.z + ((float)buffer[ix + 2] * size.z);

		return p;
	}

	public float DecodeFloat(byte[] buffer, int ix, float min, float size)
	{
		return min + ((float)buffer[ix] * size);
	}

	void OnDrawGizmosSelected()
	{
		if ( showpaths && image )
		{
			Gizmos.color = Color.red;
			Gizmos.matrix = transform.localToWorldMatrix;

			if ( image.optimized )
			{
				for ( int i = showstart; i < image.optparticles.Count; i += showparticlestep )
				{
					Vector3 lastpos = Vector3.zero;

					Color col = showcolor;

					MegaCacheParticleHistoryOpt ph = image.optparticles[i];

					for ( int j = 0; j < ph.count; j += showposstep )
					{
						float alpha = (float)j / (float)ph.count;

						float fn = alpha * (ph.count - 1);
						framenum = (int)fn;

						Vector3 lpos = DecodeV3(ph.pos, framenum * 6, ph.posmin, ph.possize) * scaleall * emitscale;

						if ( j > 0 )
						{
							col.a = 1.0f - alpha;
							Gizmos.color = col;
							Gizmos.DrawLine(lastpos, lpos);
						}

						lastpos = lpos;
					}
				}
			}
			else
			{
				for ( int i = showstart; i < image.particles.Count; i += showparticlestep )
				{
					Vector3 lastpos = Vector3.zero;

					Color col = showcolor;

					MegaCacheParticleHistory ph = image.particles[i];

					for ( int j = 0; j < ph.positions.Count; j += showposstep )
					{
						float alpha = (float)j / (float)ph.positions.Count;

						float fn = alpha * (ph.positions.Count - 1);
						framenum = (int)fn;

						Vector3 lpos = ph.positions[framenum] * scaleall * emitscale;

						if ( j > 0 )
						{
							col.a = 1.0f - alpha;
							Gizmos.color = col;
							Gizmos.DrawLine(lastpos, lpos);
						}

						lastpos = lpos;
					}
				}
			}
			Gizmos.matrix = Matrix4x4.identity;
		}
	}

	public static void LoadFile(MegaCacheParticle mod, string filename)
	{
		//if ( mod.mode == MegaCacheParticleMode.Playback )
		//{
			//LoadFilePlayBack(mod, filename);
			//return;
		//}

		StreamReader stream = File.OpenText(filename);
		string entireText = stream.ReadToEnd();
		stream.Close();

		char[] splitIdentifier = { ' ' };

		StringReader reader = new StringReader(entireText);

		int.Parse(reader.ReadLine());	// max

		int frames = int.Parse(reader.ReadLine());

		MegaCacheParticleImage img = ScriptableObject.CreateInstance<MegaCacheParticleImage>();

		bool remove = false;
		List<int>	dellist = new List<int>();

		int skip = 1;
		int scount = 0;

		for ( int i = 0; i < frames; i++ )
		{
			if ( i == frames - 1 )
				remove = true;

			int p = int.Parse(reader.ReadLine());

			Vector3 pos = Vector3.zero;
			Vector3 rot = Vector3.zero;
			Vector3 vel = Vector3.zero;

			for ( int j = 0; j < p; j++ )
			{
				string ps = reader.ReadLine();

				string[] brokenString = ps.Split(splitIdentifier, 50);

				int id = int.Parse(brokenString[0]) - 1;

				if ( remove )
				{
					// Anything still active in the last frame cant be used
					dellist.Add(id);
				}
				else
				{
					if ( scount == 0 )
					{
						MegaCacheParticleHistory ph;

						if ( id >= img.particles.Count )
						{
							ph = new MegaCacheParticleHistory();
							img.particles.Add(ph);
						}
						else
							ph = img.particles[id];

						pos.x = float.Parse(brokenString[1]);
						pos.y = float.Parse(brokenString[2]);
						pos.z = float.Parse(brokenString[3]);

						float life = float.Parse(brokenString[12]);	// / 30.0f;
						//float age = life - (float.Parse(brokenString[13]));	// / 30.0f;

						if ( mod.vel )
						{
							vel.x = float.Parse(brokenString[4]);
							vel.y = float.Parse(brokenString[5]);
							vel.z = float.Parse(brokenString[6]);

							ph.vels.Add(vel * mod.importscale);
						}

						if ( mod.rot )
						{
							rot.x = float.Parse(brokenString[7]);
							rot.y = float.Parse(brokenString[8]);
							rot.z = float.Parse(brokenString[9]);

							ph.rots.Add(rot);
						}

						if ( mod.scale )
						{
							float scale = float.Parse(brokenString[11]);
							ph.scale.Add(scale * mod.importscale);
						}

						if ( mod.spin )
						{
							float spin = float.Parse(brokenString[10]);
							ph.spin.Add(spin);
						}

						ph.life = life;
						//ph.age.Add(age);

						ph.positions.Add(pos * mod.importscale);
					}
				}
			}

			scount++;
			if ( scount == skip )
			{
				scount = 0;
			}
		}

		for ( int i = img.particles.Count - 1; i >= 0; i-- )
		{
			MegaCacheParticleHistory ph = img.particles[i];

			if ( ph.positions.Count <= 1 )
			{
				img.particles.RemoveAt(i);
			}
		}

		if ( mod.removealive )
		{
			for ( int i = dellist.Count - 1; i >= 0; i-- )
			{
				if ( dellist[i] < img.particles.Count )
					img.particles.RemoveAt(dellist[i]);
			}
		}

		mod.image = img;
	}

	public static void LoadFilePlayBack(MegaCacheParticle mod, string filename)
	{
		StreamReader stream = File.OpenText(filename);
		string entireText = stream.ReadToEnd();
		stream.Close();

		char[] splitIdentifier = { ' ' };

		StringReader reader = new StringReader(entireText);

		int.Parse(reader.ReadLine());	// max

		int frames = int.Parse(reader.ReadLine());

		MegaCacheParticleImage img = ScriptableObject.CreateInstance<MegaCacheParticleImage>();

		int skip = 1;
		int scount = 0;
		int maxp = 0;

		for ( int i = 0; i < frames; i++ )
		{
			MegaCacheParticleHistory ph = new MegaCacheParticleHistory();
			img.particles.Add(ph);

			int p = int.Parse(reader.ReadLine());

			Vector3 pos = Vector3.zero;
			Vector3 rot = Vector3.zero;
			Vector3 vel = Vector3.zero;

			for ( int j = 0; j < p; j++ )
			{
				string ps = reader.ReadLine();

				string[] brokenString = ps.Split(splitIdentifier, 50);

				//int id = int.Parse(brokenString[0]) - 1;

				if ( scount == 0 )
				{
					pos.x = float.Parse(brokenString[1]);
					pos.y = float.Parse(brokenString[2]);
					pos.z = float.Parse(brokenString[3]);

					float life = float.Parse(brokenString[12]);	// / 30.0f;
					//float age = life - (float.Parse(brokenString[13]));	// / 30.0f;

					if ( mod.vel )
					{
						vel.x = float.Parse(brokenString[4]);
						vel.y = float.Parse(brokenString[5]);
						vel.z = float.Parse(brokenString[6]);

						ph.vels.Add(vel * mod.importscale);
					}

					if ( mod.rot )
					{
						rot.x = float.Parse(brokenString[7]);
						rot.y = float.Parse(brokenString[8]);
						rot.z = float.Parse(brokenString[9]);

						ph.rots.Add(rot);
					}

					if ( mod.scale )
					{
						float scale = float.Parse(brokenString[11]);
						ph.scale.Add(scale * mod.importscale);
					}

					if ( mod.spin )
					{
						float spin = float.Parse(brokenString[10]);
						ph.spin.Add(spin);
					}

					ph.life = life;
					//ph.age.Add(age);

					ph.positions.Add(pos * mod.importscale);
				}

				if ( ph.positions.Count > maxp )
					maxp = ph.positions.Count;
			}

			scount++;
			if ( scount == skip )
				scount = 0;
		}

		for ( int i = img.particles.Count - 1; i >= 0; i-- )
		{
			MegaCacheParticleHistory ph = img.particles[i];

			if ( ph.positions.Count <= 1 )
			{
				img.particles.RemoveAt(i);
			}
		}

		img.frames = frames;
		img.maxparticles = maxp;
		mod.image = img;
	}

	public static void SaveCacheFile(MegaCacheParticle mod, string filename)
	{
		// save cache file
		FileStream fs = new FileStream(filename, FileMode.Create);
		if ( fs != null )
		{
			BinaryWriter bw = new BinaryWriter(fs);

			if ( bw != null )
			{
				MegaCacheParticleImage img = mod.image;

				int version = 1;

				bw.Write(version);
				bw.Write((int)img.particles.Count);
				bw.Write(mod.optimize);
				bw.Write(mod.saverot);
				bw.Write(mod.savevel);
				bw.Write(mod.savescale);
				bw.Write(mod.savespin);

				bw.Write(img.frames);
				bw.Write(img.maxparticles);

				for ( int i = 0; i < img.particles.Count; i++ )
				{
					MegaCacheParticleHistory ph = img.particles[i];

					bw.Write(ph.positions.Count);
					bw.Write(ph.life);
					bw.Write(ph.id);

					if ( mod.optimize )
					{
						Bounds bounds = MegaCacheUtils.GetBounds(ph.positions);

						bw.Write(bounds.min.x);
						bw.Write(bounds.min.y);
						bw.Write(bounds.min.z);

						bw.Write(bounds.size.x);
						bw.Write(bounds.size.y);
						bw.Write(bounds.size.z);

						for ( int v = 0; v < ph.positions.Count; v++ )
						{
							Vector3 pos = ph.positions[v];

							short sb = (short)(((pos.x - bounds.min.x) / bounds.size.x) * 65535.0f);
							bw.Write(sb);

							sb = (short)(((pos.y - bounds.min.y) / bounds.size.y) * 65535.0f);
							bw.Write(sb);
							sb = (short)(((pos.z - bounds.min.z) / bounds.size.z) * 65535.0f);
							bw.Write(sb);
						}
					}
					else
					{
						for ( int v = 0; v < ph.positions.Count; v++ )
						{
							Vector3 pos = ph.positions[v];
							bw.Write(pos.x);
							bw.Write(pos.y);
							bw.Write(pos.z);
						}
					}

					if ( mod.savevel )
					{
						Bounds bounds = MegaCacheUtils.GetBounds(ph.vels);

						bw.Write(bounds.min.x);
						bw.Write(bounds.min.y);
						bw.Write(bounds.min.z);

						bw.Write(bounds.size.x);
						bw.Write(bounds.size.y);
						bw.Write(bounds.size.z);

						if ( mod.optimize )
						{
							for ( int v = 0; v < ph.vels.Count; v++ )
							{
								Vector3 pos = ph.vels[v];

								byte sb = (byte)(((pos.x - bounds.min.x) / bounds.size.x) * 255.0f);
								bw.Write(sb);

								sb = (byte)(((pos.y - bounds.min.y) / bounds.size.y) * 255.0f);
								bw.Write(sb);
								sb = (byte)(((pos.z - bounds.min.z) / bounds.size.z) * 255.0f);
								bw.Write(sb);
							}
						}
						else
						{
							for ( int v = 0; v < ph.vels.Count; v++ )
							{
								Vector3 pos = ph.vels[v];
								bw.Write(pos.x);
								bw.Write(pos.y);
								bw.Write(pos.z);
							}
						}
					}

					if ( mod.savescale )
					{
						if ( mod.optimize )
						{
							Bounds bounds = MegaCacheUtils.GetBounds(ph.scale);

							bw.Write(bounds.min.x);
							bw.Write(bounds.size.x);

							for ( int v = 0; v < ph.scale.Count; v++ )
							{
								float scl = ph.scale[v];

								byte sb = (byte)(((scl - bounds.min.x) / bounds.size.x) * 255.0f);
								bw.Write(sb);
							}
						}
						else
						{
							for ( int v = 0; v < ph.scale.Count; v++ )
								bw.Write(ph.scale[v]);
						}
					}

					if ( mod.saverot )
					{
						if ( mod.optimize )
						{
							Bounds bounds = MegaCacheUtils.GetBounds(ph.rots);

							bw.Write(bounds.min.x);
							bw.Write(bounds.min.y);
							bw.Write(bounds.min.z);

							bw.Write(bounds.size.x);
							bw.Write(bounds.size.y);
							bw.Write(bounds.size.z);

							for ( int v = 0; v < ph.rots.Count; v++ )
							{
								Vector3 scl = ph.rots[v];

								byte sb = (byte)(((scl.x - bounds.min.x) / bounds.size.x) * 255.0f);
								bw.Write(sb);

								sb = (byte)(((scl.y - bounds.min.y) / bounds.size.y) * 255.0f);
								bw.Write(sb);
								sb = (byte)(((scl.z - bounds.min.z) / bounds.size.z) * 255.0f);
								bw.Write(sb);
							}
						}
						else
						{
							for ( int v = 0; v < ph.rots.Count; v++ )
							{
								Vector3 rot = ph.rots[v];
								bw.Write(rot.x);
								bw.Write(rot.y);
								bw.Write(rot.z);
							}
						}
					}

					if ( mod.savespin )
					{
						if ( mod.optimize )
						{
							Bounds bounds = MegaCacheUtils.GetBounds(ph.spin);

							bw.Write(bounds.min.x);
							bw.Write(bounds.size.x);

							for ( int v = 0; v < ph.spin.Count; v++ )
							{
								float scl = ph.spin[v];

								byte sb = (byte)(((scl - bounds.min.x) / bounds.size.x) * 255.0f);
								bw.Write(sb);
							}
						}
						else
						{
							for ( int v = 0; v < ph.scale.Count; v++ )
							{
								bw.Write(ph.scale[v]);
							}
						}
					}
				}

				bw.Close();
			}

			fs.Close();
		}
	}
}

#if false
// this needs to be a tad more clever, not just brute force setting of values but storing the state of each particle
// then playing that back as required, so can emit from the stored particle list

[AddComponentMenu("MegaCache/Particle")]
public class MegaCacheParticle : MonoBehaviour
{
	public int						framenum;
	public float					time			= 0.0f;
	public int						maxparticles	= 1000;
	public ParticleSystem			particle;
	ParticleSystem.Particle[]		particles;
	public float					fps				= 25.0f;
	public float					speed			= 1.0f;
	public MegaCacheRepeatMode		loopmode		= MegaCacheRepeatMode.Loop;
	public float					importscale		= 1.0f;
	public bool						animate			= false;
	public MegaCacheParticleImage	image;
	float							looptime		= 0.0f;
	public string					lastpath		= "";

	[ContextMenu("Help")]
	public void Help()
	{
		Application.OpenURL("http://www.west-racing.com/mf/?page_id=5896");
	}

	void Start()
	{
		if ( particle == null )
			particle = GetComponent<ParticleSystem>();

		particles = new ParticleSystem.Particle[maxparticles];
		//particle.Emit(maxparticles);
		//int count = particle.GetParticles(particles);
	}

	void LateUpdate()
	{
		if ( particle && image && image.frames.Count > 0 )
		{
			if ( animate )
			{
				looptime = image.frames.Count / fps;
				time += Time.deltaTime * speed;

				float at = time;

				switch ( loopmode )
				{
					case MegaCacheRepeatMode.Loop:
						at = Mathf.Repeat(time, Mathf.Abs(looptime));
						if ( looptime < 0.0f )
							at = looptime - at;
						break;
					case MegaCacheRepeatMode.PingPong: at = Mathf.PingPong(time, looptime); break;
					case MegaCacheRepeatMode.Clamp: at = Mathf.Clamp(time, 0.0f, looptime); break;
				}

				framenum = (int)((at / looptime) * image.frames.Count);
			}

			int count = particle.GetParticles(particles);

			MegaCacheParticleFrame fr = image.frames[framenum];

			int end = count;
			if ( fr.positions.Count < end )
				end = fr.positions.Count;

			//Debug.Log("end " + end);
			Matrix4x4 tm = transform.localToWorldMatrix;

			float life = (1.0f - ((float)framenum / (float)image.frames.Count)) * 4.0f;

			for ( int i = 0; i < end; i++ )
			{
				particles[i].position = tm.MultiplyPoint3x4(fr.positions[i]);
				particles[i].startLifetime = fr.life[i];	//.lifetime = life;
				particles[i].lifetime = fr.age[i];
			}

			Vector3 hide = new Vector3(0.0f, 10000.0f, 0.0f);
			for ( int i = end; i < count; i++ )	//maxparticles; i++ )
			{
				particles[i].position = hide;
				particles[i].lifetime = 0.0f;
			}

			particle.SetParticles(particles, count);	//maxparticles);	//fr.positions.Count);
		}
	}
}
#endif