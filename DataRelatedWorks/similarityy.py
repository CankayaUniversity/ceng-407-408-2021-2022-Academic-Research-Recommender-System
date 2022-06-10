from cgi import test
from itertools import count
from pickle import FALSE
import psycopg2
import requests
import json
import torch
from sklearn import preprocessing
#import schedule
import time
from sentence_transformers import SentenceTransformer,util
model = SentenceTransformer('all-MiniLM-L6-v2')
import os

connection = psycopg2.connect(user="postgres",
                            password="mysecretpassword",
                            host="127.0.0.1",
                            port="5432",
                            database="postgres")

                            
cursor = connection.cursor()


def ssimilarity():
    print("startttttttttttttttttttttttttttttttttttt")
    cnt=1
    postgreSQL_select_Query = "select id from new_papers_ids where done_similarity=false"
    cursor.execute(postgreSQL_select_Query)
    paper_ids = cursor.fetchall()
    print(paper_ids)
    counterForInitValues=1
    for row in paper_ids:
        print("\n","!!!",cnt,"!!!")
        print(row[0])
        postgreSQL_select_Query = "select task from papers_tasks where id='{}'".format(row[0])
        cursor.execute(postgreSQL_select_Query)
        tasks = cursor.fetchall()
        print(tasks)
        max_value=0
        max_name=" "
        for taskrow in tasks:
            
            TaskNotFoundQuery="""select exists(select 1 from task4 where task_id='{}')""".format(taskrow[0])
            cursor.execute(TaskNotFoundQuery)
            alreadyexists=cursor.fetchall()
            for rowfortruefalse in alreadyexists:
                print(rowfortruefalse[0])
            if(rowfortruefalse[0]==True):
                print("cemretest")


            
                postgreSQL_select_Query ="select quantity from task4 where task_id='{}'".format(taskrow[0])
                cursor.execute(postgreSQL_select_Query)
                one_task = cursor.fetchone()
                if(one_task[0]>max_value):
                    max_value=one_task[0]
                    max_name=taskrow[0]
        if(max_value!=0):

            postgreSQL_select_Query = "select id from papers_tasks where task='{}' and id!='{}'".format(max_name,row[0])
            cursor.execute(postgreSQL_select_Query)
            compare_ids = cursor.fetchall()
            counter=1
            for idRow in compare_ids:

                print(counterForInitValues,"    ",idRow,"    ",counter)
                postgreSQL_select_Query = "select titvec from tit_abs_vec where id='{}'".format(row[0])
                cursor.execute(postgreSQL_select_Query)
                new_abstract = cursor.fetchone()

                postgreSQL_select_Query = "select titvec from tit_abs_vec where id='{}'".format(idRow[0])
                cursor.execute(postgreSQL_select_Query)
                compare_abstract = cursor.fetchone()

                similarity=util.cos_sim(new_abstract[0],compare_abstract[0])
                print(similarity)

                print(similarity.numpy()[0])
               
                new_sim=float(similarity.numpy()[0])
                print(new_sim)
             
                query = 'insert into cosine_similarity(new_paper_id,compare_paper_id,similarity) values (%s,%s,%s)'
                record_to_insert=(row[0],idRow[0],new_sim)
                cursor.execute(query,record_to_insert)
                counter=counter+1
                connection.commit()

        postgres_insert_query = """ UPDATE new_papers_ids SET done_similarity=true WHERE id='{}'""".format(row[0])
        cursor.execute(postgres_insert_query)
        
        connection.commit()

        counterForInitValues=counterForInitValues+1
        
        cnt=cnt+1
print("start")
ssimilarity()
