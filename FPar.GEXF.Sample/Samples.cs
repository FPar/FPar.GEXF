using System.Xml;
using System.Xml.Serialization;

namespace FPar.GEXF.Sample
{
	public static class Samples
	{
		public static void Serialize(string path, gexfcontent graph)
		{
			using (var file = XmlWriter.Create(path))
			{
				var serializer = new XmlSerializer(typeof(gexfcontent));
				serializer.Serialize(file, graph);
			}
		}

		public static gexfcontent Deserialize(string path)
		{
			using (var file = XmlReader.Create(path))
			{
				var serializer = new XmlSerializer(typeof(gexfcontent));
				return (gexfcontent) serializer.Deserialize(file);
			}
		}

		/// <summary>
		///     Generates a sample graph with two nodes, edges and node attributes.
		/// </summary>
		/// <returns>A sample graph.</returns>
		/// <remarks>
		///     Refer to https://gephi.org/gexf/format/ for more information about the GEXF format.
		/// </remarks>
		public static gexfcontent GenerateSampleGraph()
		{
			const string myNodeAttributeId = "0";
			const string firstNodeId = "0";
			const string secondNodeId = "1";

			return new gexfcontent
			{
				version = gexfcontentVersion.Item12,
				graph = new graphcontent
				{
					Items = new object[]
					{
						new attributescontent
						{
							@class = classtype.node,
							attribute = new[]
							{
								new attributecontent
								{
									id = myNodeAttributeId,
									title = "My Node Attribute",
									type = attrtypetype.integer
								}
							}
						},
						new nodescontent
						{
							count = "2",
							node = new[]
							{
								new nodecontent
								{
									id = firstNodeId,
									label = "First node",
									Items = new object[]
									{
										new attvaluescontent
										{
											attvalue = new[]
											{
												new attvalue
												{
													@for = myNodeAttributeId,
													value = "3"
												}
											}
										}
									}
								},
								new nodecontent
								{
									id = secondNodeId,
									label = "Second node",
									Items = new object[]
									{
										new attvaluescontent
										{
											attvalue = new[]
											{
												new attvalue
												{
													@for = myNodeAttributeId,
													value = "5"
												}
											}
										}
									}
								}
							}
						},
						new edgescontent
						{
							count = "2",
							edge = new[]
							{
								new edgecontent
								{
									id = "0",
									source = firstNodeId,
									target = secondNodeId,
									weightSpecified = true,
									weight = 0.7f
								}
							}
						}
					}
				}
			};
		}
	}
}