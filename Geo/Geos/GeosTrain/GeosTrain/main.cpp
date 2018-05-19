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
	cout<<"GEOS��汾Ϊ��"<<GEOS_VERSION<<endl;

	typedef Coordinate PT;
	GeometryFactory factory;
	CoordinateArraySequenceFactory csf; //������һ������p1
	CoordinateSequence* cs1 = csf.create(5,2);//���2ά�㣬����ά��zʼ��Ϊ0
	cs1->setAt(PT(0,0),0);
	cs1->setAt(PT(3,0),1);
	cs1->setAt(PT(3,3),2);
	cs1->setAt(PT(0,3),3);
	cs1->setAt(PT(0,0),4); //���һ������ȣ����ɱպ�
	LinearRing* ring1 = factory.createLinearRing(cs1); //�㹹����
	Geometry* p1 = factory.createPolygon(ring1,NULL); //�߹�����

	CoordinateSequence* cs2 = csf.create(5,2); //����һ���ı���p2
	cs2->setAt(PT(2,2),0);
	cs2->setAt(PT(4,5),1);
	cs2->setAt(PT(5,5),2);
	cs2->setAt(PT(5,4),3);
	cs2->setAt(PT(2,2),4);
	LinearRing * ring2 = factory.createLinearRing(cs2);
	Geometry* p2 = (factory.createPolygon(ring2,NULL));

	CoordinateSequence *cs3 = new CoordinateArraySequence(); //����һ��������p3
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
	cout<<"ͼ1��ͼ2:"<<str(flag12)<<endl;
	cout<<"ͼ1��ͼ3:"<<str(flag13)<<endl;
	cout<<"ͼ2��ͼ3:"<<str(flag23)<<endl;

	string strin;
	cin >> strin;
}
string str(bool flag)
{
	string result=(flag==true)?"�ཻ":"���ཻ";
	return result;
}