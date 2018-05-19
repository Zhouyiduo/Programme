#include "geos.h"
#include <iostream>
#include <string>

using namespace std;


void test();
string str(bool flag);
int main(int argc,char *argv[])
{
	test();
	system("pause");
	return 1;
}


void test()
{
	cout<<"GEOS库版本为："<<GEOS_VERSION<<endl;

	typedef Coordinate PT;
	GeometryFactory factory;
	CoordinateArraySequenceFactory csf; //构建第一个矩形p1
	CoordinateSequence* cs1 = csf.create(5,2);//五个2维点，第三维度z始终为0
	cs1->setAt(PT(0,0),0);
	cs1->setAt(PT(3,0),1);
	cs1->setAt(PT(3,3),2);
	cs1->setAt(PT(0,3),3);
	cs1->setAt(PT(0,0),4); //与第一个点相等，构成闭合
	LinearRing* ring1 = factory.createLinearRing(cs1); //点构成线
	Geometry* p1 = factory.createPolygon(ring1,NULL); //线构成面

	CoordinateSequence* cs2 = csf.create(5,2); //构建一个四边形p2
	cs2->setAt(PT(2,2),0);
	cs2->setAt(PT(4,5),1);
	cs2->setAt(PT(5,5),2);
	cs2->setAt(PT(5,4),3);
	cs2->setAt(PT(2,2),4);
	LinearRing * ring2 = factory.createLinearRing(cs2);
	Geometry* p2 = (factory.createPolygon(ring2,NULL));

	CoordinateSequence *cs3 = new CoordinateArraySequence(); //构建一个三角形p3
	int xoffset=4,yoffset=4,side=2;
	cs3->add(PT(xoffset, yoffset));
	cs3->add(PT(xoffset, yoffset+side));
	cs3->add(PT(xoffset+side, yoffset+side));
	cs3->add(PT(xoffset, yoffset));
	LinearRing * ring3 = factory.createLinearRing(cs3);
	Geometry* p3 = (factory.createPolygon(ring3,NULL));
	bool flag12=p1->intersects(p2);
	bool flag13=p1->intersects(p3);
	bool flag23=p2->intersects(p3);
	cout<<"图1与图2:"<<str(flag12)<<endl;
	cout<<"图1与图3:"<<str(flag13)<<endl;
	cout<<"图2与图3:"<<str(flag23)<<endl;

	string strin;
	cin >> strin;
}
string str(bool flag)
{
	string result=(flag==true)?"相交":"不相交";
	return result;
}