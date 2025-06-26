import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-quotes',
  imports: [],
  templateUrl: './quotes.html',
  styleUrl: './quotes.scss'
})
export class Quotes implements OnInit {
  quotes: any[] = [];

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.api.get<any[]>('quotes').subscribe({
      next: (data) => (this.quotes = data),
      error: (err) => console.error('Error fetching quotes: ', err)
    });
  }
}
