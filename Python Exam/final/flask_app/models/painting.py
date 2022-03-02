from flask_app.config.mysqlconnection import connectToMySQL
from flask import flash
from flask_app.models.user import User
DB = 'final'
# Database


class Painting():
    def __init__(self, data):
        self.id = data['id']
        self.title = data['title']
        self.description = data['description']
        self.price = data['price']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']
        self.creator_id = data['creator_id']
        self.creator = None
# Painting class with attributes

    @classmethod
    def create_new_painting(cls, data):
        query = "INSERT INTO paintings (title, description, price, creator_id) VALUES (%(title)s, %(description)s, %(price)s, %(creator_id)s)"
        result = connectToMySQL(DB).query_db(query, data)
        return result
# Insert painting into DB

    @classmethod
    def get_all_paintings(cls):
        query = "SELECT * FROM paintings JOIN users ON paintings.creator_id=users.id;"
        results = connectToMySQL(DB).query_db(query)
        paintings = []
        for item in results:
            new_painting = cls(item)
            new_user_data = {
                'id': item['users.id'],
                'first_name': item['first_name'],
                'last_name': item['last_name'],
                'email': item['email'],
                'password': item['password'],
                'created_at': item['users.created_at'],
                'updated_at': item['users.updated_at']
            }
            new_user = User(new_user_data)
            new_painting.creator = new_user
            paintings.append(new_painting)
        return paintings
# Show all paintings

    @classmethod
    def get_painting_by_id(cls, data):
        query = "SELECT * FROM paintings JOIN users ON paintings.creator_id=users.id WHERE paintings.id = %(id)s;"
        result = connectToMySQL(DB).query_db(query, data)
        painting = cls(result[0])
        new_user_data = {
            'id': result[0]['users.id'],
            'first_name': result[0]['first_name'],
            'last_name': result[0]['last_name'],
            'email': result[0]['email'],
            'password': result[0]['password'],
            'created_at': result[0]['users.created_at'],
            'updated_at': result[0]['users.updated_at']
        }
        new_user = User(new_user_data)
        painting.creator = new_user
        return painting
# Sort paintings by user ID
    
    @classmethod
    def delete_painting(cls, data):
        query = "DELETE FROM paintings WHERE id=%(id)s;"
        connectToMySQL(DB).query_db(query, data)
# Delete painting by user ID

    @classmethod
    def update_painting(cls, data):
        query = "UPDATE paintings SET title= %(title)s, description=%(description)s, price=%(price)s WHERE id= %(id)s;"
        connectToMySQL(DB).query_db(query, data)
# Edit painting by user ID

    @staticmethod
    def validate_painting(data):
        is_valid = True
        if len(data['title']) < 2:
            is_valid = False
            flash("Title must be at least 2 characters long")
        if len(data['description']) < 10:
            is_valid = False
            flash("Description must be at least 10 characters long")
        if len(data['price']) <= 0:
            is_valid = False
            flash("Price must be greater than 0")
        return is_valid
# Validate painting