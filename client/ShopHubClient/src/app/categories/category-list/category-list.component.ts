import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { AddCategoryModalComponent } from '../add-category-modal/add-category-modal.component';
import { Categories } from '../../shared/constants';

@Component({
  selector: 'app-category-list',
  imports: [MatButtonModule],
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.scss',
})
export class CategoryListComponent {
  constructor(public dilaog: MatDialog) {}
  onAddCategory() {
    const dialogRef = this.dilaog.open(AddCategoryModalComponent, {
      width: '500px',
      data: { categories: Categories },
    });

    dialogRef.afterClosed().subscribe((loadCategories: boolean) => {
      if (loadCategories) {
        this.loadCategories();
      }
    });
  }

  loadCategories() {}
}
