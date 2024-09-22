import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Product } from "../Models/product";
import { Pagination } from "../Models/pagination";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrl: "./app.component.scss",
})
export class AppComponent implements OnInit {
  title = "Client";
  products: Product[] = [];
  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.http
      .get<Pagination<Product[]>>("https://localhost:5001/api/products")
      .subscribe({
        next: (res) => (this.products = res.data),
        error: (err) => console.log(err),
        complete: () => {
          console.log("finish"), console.log("close");
        },
      });
  }
}
