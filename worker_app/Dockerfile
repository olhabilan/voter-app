FROM python:2
ADD worker.py /
RUN pip install pymongo psycopg2-binary
CMD ["python", "./worker.py"]
