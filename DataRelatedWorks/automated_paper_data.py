from cgi import test
from itertools import count
from pickle import FALSE
import psycopg2
import requests
import json
import schedule
import time
import playsound as ps
from sentence_transformers import SentenceTransformer
from sqlalchemy import false, true
model = SentenceTransformer('all-MiniLM-L6-v2')

connection = psycopg2.connect(user="postgres",
                            password="mysecretpassword",
                            host="127.0.0.1",
                            port="5432",
                            database="postgres")

                            
cursor = connection.cursor()


def paper_crawler():
    existNext=true
    #nextExist="doesn't matter"
    #pageNumber=1880 #needs to be taken from database next time ogulcan

    crawler_query = "select last_page_num from crawler_last_pagenum"
    cursor.execute(crawler_query)
    pageNumbers = cursor.fetchone()
    print(pageNumbers)
    print(pageNumbers[0],"\n")
    pageNumber=pageNumbers[0]
    print(pageNumber)
   


    
    while(existNext==true):

        link = "https://paperswithcode.com/api/v1/papers/?page={}&items_per_page=500".format(pageNumber)
        #older
        # while(nextExist is not None):
        #     print(pageNumber)

        #     response = requests.get(link)
        #     print(response.status_code)

        #     #print(response.content)

        #     jsonResponse = response.json()
        #     print(len(jsonResponse['results']))
        #     pageNumber=pageNumber+1
        #     link = "https://paperswithcode.com/api/v1/papers/?page={}&items_per_page=500".format(pageNumber)
        #     nextExist=jsonResponse['next']
        
        #newer
        response = requests.get(link)
        print(response.status_code)
        jsonResponse = response.json()
        
        if(jsonResponse['next'] is None or jsonResponse['next'] == '' ):
            existNext=false
            print("There is no next page")
        elif (jsonResponse['next'] is not None):
            print("there is next page, page number increased by one {} to {}".format(pageNumber,(pageNumber+1)))
            pageNumber=pageNumber+1
            crawler_update_query = """ UPDATE crawler_last_pagenum SET last_page_num={} """.format(pageNumber)
            #print(postgres_insert_query)
            cursor.execute(crawler_update_query)
            connection.commit()     

        print(len(jsonResponse['results']))
        
        #amountOfPaperRange=jsonResponse['count']%500
        amountOfPaperRange=len(jsonResponse['results'])
        fl=1
        insertable_count=1
        test_flag=1
        for x in range(amountOfPaperRange):
            
            tasks_str=""
            print(fl)
            
            #print(jsonResponse['next'])
            #print(jsonResponse['results'][x]['id'])
            

            
            #Test whether paper has any tasks if not dont write that paper in database
            #if(jsonResponse['results'][x]['abstract'] is not None and jsonResponse['results'][x]['abstract']!=''  and jsonResponse['results'][x]['title'] is not None and jsonResponse['results'][x]['title']!='' and jsonResponse['results'][x]['url_abs'] is not None and jsonResponse['results'][x]['url_abs']!='' and jsonResponse['results'][x]['url_pdf'] is not None and jsonResponse['results'][x]['url_pdf']!='' ):
            if(jsonResponse['results'][x]['abstract'] is not None and jsonResponse['results'][x]['abstract']!=''  and jsonResponse['results'][x]['title'] is not None and jsonResponse['results'][x]['title']!=''):

                link = "https://paperswithcode.com/api/v1/papers/{}/tasks/?page=1&items_per_page=100".format(jsonResponse['results'][x]['id'])
                print(link)
                response2 = requests.get(link)
                if(response2.status_code!=404):
                    print(jsonResponse['results'][x]['id'],"not 404")
                    jsonResponse2 = response2.json()
                    if (jsonResponse2['count']!=0):
                        
                        authors_array=",".join(jsonResponse['results'][x]['authors'])
                        #print(authors_array)
                        print(jsonResponse['results'][x]['id'],"has task/s amount:",jsonResponse2['count'])
                        print("tasks:")
                        for y in range(jsonResponse2['count']):
                            
                            
                            print(jsonResponse2['results'][y]['id']) #oldu bunu uygula
                            if(y==0):
                                tasks_str=tasks_str+jsonResponse2['results'][y]['id']
                            else:
                                tasks_str=tasks_str+","+jsonResponse2['results'][y]['id']
                            #print(jsonResponse['results'][x]['name'])
                            #print(jsonResponse['results'][x]['description'])

                            print(" ")
                            
                            
                            if((y+1)==jsonResponse2['count']):
                                print("tasks_str:",tasks_str)

                                postgres_insert_query ="""select exists(select 1 from papers7 where id='{}')""".format(jsonResponse['results'][x]['id'])
                                cursor.execute(postgres_insert_query)
                                alreadyexists=cursor.fetchall()
                                for rowfortruefalse in alreadyexists:
                                    print(rowfortruefalse[0])
                                if(rowfortruefalse[0]==False):
                                    print("insertable count:",insertable_count)
                                    insertable_count=insertable_count+1
                                    print("{} Doesnt exists in database".format(jsonResponse['results'][x]['id']) )
                                    postgres_insert_query = """ INSERT INTO new_papers_ids (id) VALUES ('{}')""".format(jsonResponse['results'][x]['id'])
                                    record_to_insert = (jsonResponse['results'][x]['id'])
                                    #cursor.execute(postgres_insert_query, record_to_insert)
                                    cursor.execute(postgres_insert_query)
                                    
                                    #connection.commit() #yoruma aldım ogulcan
                                    print("inserted in newly added papers")

                                    print(jsonResponse['results'][x]['published'])
                                    newTitle=jsonResponse['results'][x]['title']
                                    newTitle = newTitle.replace("'"," ")

                                    
                                    newAbstract=jsonResponse['results'][x]['abstract']
                                    newAbstract = newAbstract.replace("'"," ")

                                    #papers7 table has 15 columns
                                    if(jsonResponse['results'][x]['published']=='' or jsonResponse['results'][x]['published']==None ):
                                        postgres_insert_query = """ INSERT INTO papers7 (id,title,abstract,authors,pdf_url,github_url,vote_counter,vote_total,view_counter,task_types,done_task,rsponse_fourzrofour,done_tasks_str,done_vec) VALUES ('{}','{}','{}','{}','{}','{}','{}','{}','{}','{}','{}','{}','{}','{}')""".format(jsonResponse['results'][x]['id'], newTitle,newAbstract,authors_array,jsonResponse['results'][x]['url_pdf'],jsonResponse['results'][x]['url_abs'],0,0,0,tasks_str,'TRUE','FALSE','FALSE','FALSE')
                                    else:
                                        postgres_insert_query = """ INSERT INTO papers7 (id,title,abstract,published_date,authors,pdf_url,github_url,vote_counter,vote_total,view_counter,task_types,done_task,rsponse_fourzrofour,done_tasks_str,done_vec) VALUES ('{}','{}','{}','{}','{}','{}','{}','{}','{}','{}','{}','{}','{}','{}','{}')""".format(jsonResponse['results'][x]['id'], newTitle, newAbstract,jsonResponse['results'][x]['published'],authors_array,jsonResponse['results'][x]['url_pdf'],jsonResponse['results'][x]['url_abs'],0,0,0,tasks_str,'TRUE','FALSE','FALSE','FALSE')
                                    
                                    #record_to_insert = (jsonResponse['results'][x]['id'], jsonResponse['results'][x]['title'], jsonResponse['results'][x]['abstract'],jsonResponse['results'][x]['published'],authors_array,jsonResponse['results'][x]['url_pdf'],jsonResponse['results'][x]['url_abs'],0,0,0,tasks_str,TRUE,FALSE,FALSE,FALSE )
                                    cursor.execute(postgres_insert_query)
                                    #connection.commit() #yoruma aldım ogulcan
                                    print("inserted in added papers7")
                                




                    elif(jsonResponse2['count']==0):
                        print(jsonResponse['results'][x]['id']," has zero tasks")
                elif(response2.status_code==404):
                    print(jsonResponse['results'][x]['id']," 404 404 404")

                        # postgres_insert_query = """ INSERT INTO new_papers_ids (id) VALUES (%s)"""
                        # record_to_insert = (jsonResponse['results'][x]['id'])
                        # cursor.execute(postgres_insert_query, record_to_insert)
                        # connection.commit()

                        #papers6 table has 15 columns
                        # postgres_insert_query = """ INSERT INTO papers7 (id,title,abstract,published_date,authors,pdf_url,github_url,vote_counter,vote_total,view_counter,task_types,done_task,rsponse_fourzrofour,done_taks_str,done_vec) VALUES (%s,%s,%s,%S,%s,%s,%s,%s,%S,%s,%s,%s,%s,%S,%s)"""
                        # record_to_insert = (jsonResponse['results'][x]['id'], jsonResponse['results'][x]['name'], jsonResponse['results'][x]['description'], row)
                        # cursor.execute(postgres_insert_query, record_to_insert) 
            print()
            fl=fl+1
            test_flag=test_flag+1
            
            
            #if(test_flag==500):
            #    return
        print(jsonResponse['next'])
        if(jsonResponse['next'] is None):
            existNext=false         
    print(jsonResponse['next'])        


def strToArray():
    cnt=1
    postgreSQL_select_Query = "select id,task_types from papers7 where done_tasks_str=false "
    cursor.execute(postgreSQL_select_Query)
    paper_tasks = cursor.fetchall()
    print(paper_tasks)
    for row in paper_tasks:
        print("!!!",cnt,"!!!")
        #print(row)
        print(row[0])
        print(row[1])
        arr_len=len(paper_tasks)
        #print(arr_len)
        list = row[1].split(",")
        print("list: ",list)
        list_len=len(list)
        print(list_len)
        print("\n")

        postgres_insert_query = """ UPDATE papers7 SET done_tasks_str=true WHERE id='{}'""".format(row[0])
        #print(postgres_insert_query)
        cursor.execute(postgres_insert_query)
        connection.commit()

        for x in list:
            

            # INSERT INTO papers_tasks(id,task) 
            # VALUES('test_id','test_task');
            
            postgres_insert_query = """ INSERT INTO papers_tasks (id, task) VALUES (%s,%s)"""
            record_to_insert = (row[0],x)
            cursor.execute(postgres_insert_query, record_to_insert)
            connection.commit()
            print("id: "+row[0]+" task: "+x)
            
            
        cnt=cnt+1


            # postgres_insert_query = """ INSERT INTO task2 (task_id, task_name, description, area_type) VALUES (%s,%s,%s,%s)"""
            # record_to_insert = (jsonResponse['results'][x]['id'], jsonResponse['results'][x]['name'], jsonResponse['results'][x]['description'], row)
            # cursor.execute(postgres_insert_query, record_to_insert)

            # print(x)
            # print(jsonResponse['results'][x]['id']) #oldu bunu uygula
            # #print(jsonResponse['results'][x]['name'])
            # #print(jsonResponse['results'][x]['description']+"\n")

            # connection.commit()
            # count = cursor.rowcount

        print("\n")


def add_task_quantity():
    print("start")
    cnt=1
    postgreSQL_select_Query = "select task_id from task2 where done_quantity=false limit 500"
    cursor.execute(postgreSQL_select_Query)
    paper_tasks = cursor.fetchall()
    print(paper_tasks)
    for row in paper_tasks:
        print("\n","!!!",cnt,"!!!")
        #print(row)
        print(row[0])
        postgreSQL_select_Query_Count = """ select count(*) from papers_tasks where task='{}' """.format(row[0])
        cursor.execute(postgreSQL_select_Query_Count)
        task_Count = cursor.fetchone()
        print(task_Count[0])
        

        postgres_insert_query = """ UPDATE task2 SET quantity={} WHERE task_id='{}'""".format(task_Count[0],row[0])
        cursor.execute(postgres_insert_query)
        #connection.commit()
        print("quantity set")

        postgres_insert_query = """ UPDATE task2 SET done_quantity=true WHERE task_id='{}'""".format(row[0])
        cursor.execute(postgres_insert_query)
        #connection.commit()
        print("done_quantity set")

        cnt=cnt+1

def for_data_query():
    cnt=1
    print("start")
    postgreSQL_select_Query = "select id from papers7 where done_vec=false "
    cursor.execute(postgreSQL_select_Query)
    paper_ids = cursor.fetchall()
    print("paper_ids=",paper_ids)

    for row in paper_ids:
        print("!!!",cnt,"!!!")
        print(row[0])

        print(row)

        # postgres_insert_query = """ INSERT INTO tit_abs_vec(id) VALUES (%s)"""
        # record_to_insert = (row[0])
        # cursor.execute(postgres_insert_query,record_to_insert)
        # connection.commit()

        postgreSQL_select_Query_Count = """ select title from papers7 where id='{}' """.format(row[0])
        cursor.execute(postgreSQL_select_Query_Count)
        paper_title = cursor.fetchone()
        vector_title=insert_sentence_vector(paper_title[0])

        postgreSQL_select_Query_Count = """ select abstract from papers7 where id='{}' """.format(row[0])
        cursor.execute(postgreSQL_select_Query_Count)
        paper_title = cursor.fetchone()
        vector_abstract=insert_sentence_vector(paper_title[0])

        query = 'insert into tit_abs_vec(id,titvec,absvec) values (%s, ARRAY [' + vector_title +'],ARRAY [' + vector_abstract +'])'
        record_to_insert = (row)
        cursor.execute(query,record_to_insert)
        connection.commit()
        print("inserted id,titvec,absvec")
        postgres_insert_query = """ UPDATE papers7 SET done_vec=true WHERE id='{}'""".format(row[0])
        cursor.execute(postgres_insert_query)
        connection.commit()
        print("done_vec set true")
        cnt=cnt+1
        print(" ")


        
def insert_sentence_vector(text):

    res = model.encode(text)

    str_list = [str(item) for item in res]
    vector = ','.join(str_list)
    return(vector)


paper_crawler()
print("PAPER_CRAWLER DONE--------PAPER_CRAWLER DONE---------------PAPER_CRAWLER DONE---------------PAPER_CRAWLER DONE---------------PAPER_CRAWLER DONE--------")
print("PAPER_CRAWLER DONE--------PAPER_CRAWLER DONE---------------PAPER_CRAWLER DONE---------------PAPER_CRAWLER DONE---------------PAPER_CRAWLER DONE--------")
print("PAPER_CRAWLER DONE--------PAPER_CRAWLER DONE---------------PAPER_CRAWLER DONE---------------PAPER_CRAWLER DONE---------------PAPER_CRAWLER DONE--------")

#strToArray()
print("strToArray DONE--------strToArray DONE---------------strToArrayDONE---------------strToArray DONE---------------strToArray DONE--------")
print("strToArray DONE--------strToArray DONE---------------strToArrayDONE---------------strToArray DONE---------------strToArray DONE--------")
print("strToArray DONE--------strToArray DONE---------------strToArrayDONE---------------strToArray DONE---------------strToArray DONE--------")

#for_data_query()
print("for_data_query DONE--------for_data_query DONE---------------for_data_query DONE---------------for_data_query DONE---------------for_data_query DONE--------")
print("for_data_query DONE--------for_data_query DONE---------------for_data_query DONE---------------for_data_query DONE---------------for_data_query DONE--------")
print("for_data_query DONE--------for_data_query DONE---------------for_data_query DONE---------------for_data_query DONE---------------for_data_query DONE--------")

print("done completetly")
